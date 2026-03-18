using AutoMapper;
using NexUs.Models.Entities;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Users;
using NexUs.Models.DTO.Roles;

namespace NexUs.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            // Entity to DTO mappings
            CreateMap<User, UserResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                    $"{src.FirstName} {src.MiddleName} {src.LastName} {src.Suffix}".Replace("  ", " ").Trim()))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src =>
                    src.UserRoles.Select(ur => ur.Role)))
                .ForMember(dest => dest.PreferredBuildingId, opt => opt.Ignore())
                .ForMember(dest => dest.PreferredBuildingName, opt => opt.Ignore());

            CreateMap<User, UserListDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                    $"{src.FirstName} {src.MiddleName} {src.LastName} {src.Suffix}".Replace("  ", " ").Trim()))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src =>
                    src.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault()));

            CreateMap<Address, AddressDto>();

            // DTO to Entity mappings
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
                .ForMember(dest => dest.AuditLogs, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore());

            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.DeletedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
                .ForMember(dest => dest.AuditLogs, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore())

                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
