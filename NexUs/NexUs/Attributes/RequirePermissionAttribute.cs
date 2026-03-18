using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using NexUs.Extensions;
using NexUs.Models.DTO.Common;
using NexUs.Services.Interfaces;

namespace NexUs.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class RequirePermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _permission;

        public RequirePermissionAttribute(string permission) => _permission = permission;

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.GetCurrentUserId();
            if (userId == null)
            {
                context.Result = new UnauthorizedObjectResult(
                    ApiResponse<object>.ErrorResponse("Unauthorized"));
                return;
            }

            var cache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
            var permService = context.HttpContext.RequestServices.GetRequiredService<IPermissionService>();

            var cacheKey = $"user_perms_{userId}";
            if (!cache.TryGetValue(cacheKey, out List<string>? userPerms))
            {
                userPerms = await permService.GetUserPermissionsAsync(userId.Value);
                cache.Set(cacheKey, userPerms, TimeSpan.FromMinutes(5));
            }

            if (userPerms == null || !userPerms.Contains(_permission))
            {
                context.Result = new ObjectResult(
                    ApiResponse<object>.ErrorResponse($"Forbidden: you do not have the '{_permission}' permission."))
                { StatusCode = 403 };
            }
        }
    }
}
