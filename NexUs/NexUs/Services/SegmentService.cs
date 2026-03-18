using Microsoft.EntityFrameworkCore;
using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.DTO.Marketing;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;
using NexUs.Utilities;
using System.Text.Json;

namespace NexUs.Services
{
    public class SegmentService : ISegmentService
    {
        private readonly ApplicationDbContext _context;

        public SegmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        private static SegmentListDto ToListDto(Segment s) => new()
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Type = s.Type,
            RulesJson = s.RulesJson,
            IsActive = s.IsActive,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt,
            CreatedByName = s.CreatedByUser != null ? $"{s.CreatedByUser.FirstName} {s.CreatedByUser.LastName}".Trim() : null,
            UpdatedByName = s.UpdatedByUser != null ? $"{s.UpdatedByUser.FirstName} {s.UpdatedByUser.LastName}".Trim() : null
        };

        public async Task<PagedResultDto<SegmentListDto>> GetAllAsync(PaginationDto pagination)
        {
            var query = _context.Segments.Where(s => s.DeletedAt == null)
                .Include(s => s.CreatedByUser).Include(s => s.UpdatedByUser).AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(s => s.Name.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(s => s.CreatedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

            return new PagedResultDto<SegmentListDto> { Items = items.Select(ToListDto).ToList(), TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize };
        }

        public async Task<PagedResultDto<SegmentListDto>> GetArchivedAsync(PaginationDto pagination)
        {
            var query = _context.Segments.Where(s => s.DeletedAt != null)
                .Include(s => s.CreatedByUser).Include(s => s.UpdatedByUser).AsQueryable();

            if (!string.IsNullOrEmpty(pagination.SearchTerm))
            {
                var term = pagination.SearchTerm.ToLower();
                query = query.Where(s => s.Name.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(s => s.DeletedAt)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

            return new PagedResultDto<SegmentListDto> { Items = items.Select(ToListDto).ToList(), TotalCount = totalCount, PageNumber = pagination.PageNumber, PageSize = pagination.PageSize };
        }

        public async Task<SegmentResponseDto?> GetByIdAsync(int id)
        {
            var s = await _context.Segments.Include(x => x.CreatedByUser).Include(x => x.UpdatedByUser)
                .FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
            if (s == null) return null;
            var dto = ToListDto(s);
            return new SegmentResponseDto { Id = dto.Id, Name = dto.Name, Description = dto.Description, Type = dto.Type, RulesJson = dto.RulesJson, IsActive = dto.IsActive, CreatedAt = dto.CreatedAt, UpdatedAt = dto.UpdatedAt, CreatedByName = dto.CreatedByName, UpdatedByName = dto.UpdatedByName };
        }

        public async Task<SegmentResponseDto> CreateAsync(CreateSegmentDto dto, int? currentUserId)
        {
            var entity = new Segment { Name = dto.Name, Description = dto.Description, Type = dto.Type, RulesJson = dto.RulesJson, IsActive = dto.IsActive, CreatedBy = currentUserId, UpdatedBy = currentUserId };
            _context.Segments.Add(entity);
            await _context.SaveChangesAsync();
            return await GetByIdAsync(entity.Id) ?? throw new Exception("Failed to load segment.");
        }

        public async Task<SegmentResponseDto?> UpdateAsync(int id, UpdateSegmentDto dto, int? currentUserId)
        {
            var entity = await _context.Segments.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return null;
            entity.Name = dto.Name; entity.Description = dto.Description; entity.Type = dto.Type; entity.RulesJson = dto.RulesJson; entity.IsActive = dto.IsActive; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync();
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteAsync(int id, int? currentUserId)
        {
            var entity = await _context.Segments.FindAsync(id);
            if (entity == null || entity.DeletedAt != null) return false;
            entity.DeletedAt = DateTimeHelper.PhilippineNow; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<bool> RestoreAsync(int id, int? currentUserId)
        {
            var entity = await _context.Segments.FindAsync(id);
            if (entity == null || entity.DeletedAt == null) return false;
            entity.DeletedAt = null; entity.UpdatedBy = currentUserId;
            await _context.SaveChangesAsync(); return true;
        }

        public async Task<bool> PermanentDeleteAsync(int id)
        {
            var entity = await _context.Segments.FindAsync(id);
            if (entity == null) return false;
            _context.Segments.Remove(entity); await _context.SaveChangesAsync(); return true;
        }

        public async Task<List<string>> GetFieldValuesAsync(string field)
        {
            var f = field?.ToLower() ?? "";
            var users = _context.Users.Where(u => u.DeletedAt == null);

            switch (f)
            {
                case "leadtype":
                    return ["Registered", "Unregistered"];

                case "leadstatus":
                    return ["New", "Contacted", "Interested", "Converted", "Closed"];

                case "leadsource":
                    return ["Registration", "Manual", "Import"];

                case "role":
                    return await _context.Roles.Select(r => r.Name).Distinct().OrderBy(v => v).ToListAsync();

                case "name":
                    var firstNames = await users.Select(u => u.FirstName).Distinct().ToListAsync();
                    var lastNames = await users.Select(u => u.LastName).Distinct().ToListAsync();
                    var middleNames = await users.Where(u => u.MiddleName != null).Select(u => u.MiddleName!).Distinct().ToListAsync();
                    return firstNames.Union(lastNames).Union(middleNames).Where(n => !string.IsNullOrWhiteSpace(n)).Distinct().OrderBy(v => v).ToList();

                case "suffix":
                    return await users.Where(u => u.Suffix != null && u.Suffix != "").Select(u => u.Suffix!).Distinct().OrderBy(v => v).ToListAsync();

                case "email":
                    return await users.Select(u => u.Email).Distinct().OrderBy(v => v).ToListAsync();

                case "phone":
                    return await users.Where(u => u.Phone != null && u.Phone != "").Select(u => u.Phone!).Distinct().OrderBy(v => v).ToListAsync();

                case "gender":
                    return await users.Where(u => u.Gender != null && u.Gender != "").Select(u => u.Gender!).Distinct().OrderBy(v => v).ToListAsync();

                case "nationality":
                    return await users.Where(u => u.Nationality != null && u.Nationality != "").Select(u => u.Nationality!).Distinct().OrderBy(v => v).ToListAsync();

                case "streetbarangay":
                    return await _context.Addresses.Where(a => a.StreetBarangay != "").Select(a => a.StreetBarangay).Distinct().OrderBy(v => v).ToListAsync();

                case "region":
                    return await _context.Addresses.Where(a => a.Region != "").Select(a => a.Region).Distinct().OrderBy(v => v).ToListAsync();

                case "province":
                    return await _context.Addresses.Where(a => a.Province != "").Select(a => a.Province).Distinct().OrderBy(v => v).ToListAsync();

                case "city":
                    return await _context.Addresses.Where(a => a.CityMunicipality != "").Select(a => a.CityMunicipality).Distinct().OrderBy(v => v).ToListAsync();

                case "postal":
                    return await _context.Addresses.Where(a => a.Postal != "").Select(a => a.Postal).Distinct().OrderBy(v => v).ToListAsync();

                default:
                    return [];
            }
        }

        public async Task<List<(int? UserId, string Email, string FirstName, string LastName)>> EvaluateAsync(int segmentId)
        {
            var segment = await _context.Segments.FindAsync(segmentId);
            if (segment == null) return [];

            // Parse all rules
            List<SegmentRule> allRules = [];
            if (!string.IsNullOrEmpty(segment.RulesJson))
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    allRules = JsonSerializer.Deserialize<List<SegmentRule>>(segment.RulesJson, options) ?? [];
                }
                catch { /* ignore malformed rules */ }
            }

            // Separate lead-specific rules from user-field rules
            var leadTypeRule   = allRules.FirstOrDefault(r => r.Field?.ToLower() == "leadtype");
            var leadStatusRule = allRules.FirstOrDefault(r => r.Field?.ToLower() == "leadstatus");
            var leadSourceRule = allRules.FirstOrDefault(r => r.Field?.ToLower() == "leadsource");
            var userRules      = allRules.Where(r => r.Field?.ToLower() is not ("leadtype" or "leadstatus" or "leadsource")).ToList();

            var leadTypeVal       = leadTypeRule?.Value?.ToLower() ?? "registered";
            bool includeRegistered   = leadTypeRule == null || leadTypeVal is "registered" or "all";
            bool includeUnregistered = leadTypeVal is "unregistered" or "all";

            var results = new List<(int? UserId, string Email, string FirstName, string LastName)>();

            // ── Pool 1: registered users ──────────────────────────────────────
            if (includeRegistered)
            {
                var usersQuery = _context.Users
                    .Where(u => u.DeletedAt == null)
                    .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                    .Include(u => u.Address)
                    .AsQueryable();

                foreach (var rule in userRules)
                {
                    var field  = rule.Field?.ToLower() ?? "";
                    var op     = rule.Operator?.ToLower() ?? "equals";
                    var valStr = rule.Value ?? "";

                    var vals = valStr.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(v => v.Trim().ToLower())
                                     .Where(v => !string.IsNullOrEmpty(v))
                                     .ToList();

                    if (!vals.Any()) continue;

                    switch (field)
                    {
                        case "role":
                            if (op is "equals" or "is")
                                usersQuery = usersQuery.Where(u => u.UserRoles.Any(ur => vals.Contains(ur.Role.Name.ToLower())));
                            else if (op is "notequals" or "isnot")
                                usersQuery = usersQuery.Where(u => !u.UserRoles.Any(ur => vals.Contains(ur.Role.Name.ToLower())));
                            break;

                        case "name":
                            if (op is "equals" or "is")
                                usersQuery = usersQuery.Where(u => vals.Contains(u.FirstName.ToLower()) || vals.Contains(u.LastName.ToLower()) || vals.Contains((u.MiddleName ?? "").ToLower()));
                            else if (op is "notequals" or "isnot")
                                usersQuery = usersQuery.Where(u => !vals.Contains(u.FirstName.ToLower()) && !vals.Contains(u.LastName.ToLower()) && !vals.Contains((u.MiddleName ?? "").ToLower()));
                            else if (op == "contains")
                                usersQuery = usersQuery.Where(u => vals.Any(v => u.FirstName.ToLower().Contains(v) || u.LastName.ToLower().Contains(v) || (u.MiddleName ?? "").ToLower().Contains(v)));
                            else if (op == "startswith")
                                usersQuery = usersQuery.Where(u => vals.Any(v => u.FirstName.ToLower().StartsWith(v) || u.LastName.ToLower().StartsWith(v)));
                            else if (op == "endswith")
                                usersQuery = usersQuery.Where(u => vals.Any(v => u.FirstName.ToLower().EndsWith(v) || u.LastName.ToLower().EndsWith(v)));
                            break;

                        case "email":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => vals.Contains(u.Email.ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => !vals.Contains(u.Email.ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => vals.Any(v => u.Email.ToLower().Contains(v)));
                            else if (op == "startswith") usersQuery = usersQuery.Where(u => vals.Any(v => u.Email.ToLower().StartsWith(v)));
                            else if (op == "endswith") usersQuery = usersQuery.Where(u => vals.Any(v => u.Email.ToLower().EndsWith(v)));
                            break;

                        case "gender":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => vals.Contains((u.Gender ?? "").ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => !vals.Contains((u.Gender ?? "").ToLower()));
                            break;

                        case "nationality":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => vals.Contains((u.Nationality ?? "").ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => !vals.Contains((u.Nationality ?? "").ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => vals.Any(v => (u.Nationality ?? "").ToLower().Contains(v)));
                            break;

                        case "middlename":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => vals.Contains((u.MiddleName ?? "").ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => !vals.Contains((u.MiddleName ?? "").ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => vals.Any(v => (u.MiddleName ?? "").ToLower().Contains(v)));
                            break;

                        case "suffix":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => vals.Contains((u.Suffix ?? "").ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => !vals.Contains((u.Suffix ?? "").ToLower()));
                            break;

                        case "phone":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => vals.Contains((u.Phone ?? "").ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => !vals.Contains((u.Phone ?? "").ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => vals.Any(v => (u.Phone ?? "").ToLower().Contains(v)));
                            else if (op == "startswith") usersQuery = usersQuery.Where(u => vals.Any(v => (u.Phone ?? "").ToLower().StartsWith(v)));
                            break;

                        case "streetbarangay":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => u.Address != null && vals.Contains(u.Address.StreetBarangay.ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => u.Address == null || !vals.Contains(u.Address.StreetBarangay.ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => u.Address != null && vals.Any(v => u.Address.StreetBarangay.ToLower().Contains(v)));
                            break;

                        case "region":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => u.Address != null && vals.Contains(u.Address.Region.ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => u.Address == null || !vals.Contains(u.Address.Region.ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => u.Address != null && vals.Any(v => u.Address.Region.ToLower().Contains(v)));
                            break;

                        case "province":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => u.Address != null && vals.Contains(u.Address.Province.ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => u.Address == null || !vals.Contains(u.Address.Province.ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => u.Address != null && vals.Any(v => u.Address.Province.ToLower().Contains(v)));
                            break;

                        case "city":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => u.Address != null && vals.Contains(u.Address.CityMunicipality.ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => u.Address == null || !vals.Contains(u.Address.CityMunicipality.ToLower()));
                            else if (op == "contains") usersQuery = usersQuery.Where(u => u.Address != null && vals.Any(v => u.Address.CityMunicipality.ToLower().Contains(v)));
                            break;

                        case "postal":
                            if (op is "equals" or "is") usersQuery = usersQuery.Where(u => u.Address != null && vals.Contains(u.Address.Postal.ToLower()));
                            else if (op is "notequals" or "isnot") usersQuery = usersQuery.Where(u => u.Address == null || !vals.Contains(u.Address.Postal.ToLower()));
                            else if (op == "startswith") usersQuery = usersQuery.Where(u => u.Address != null && vals.Any(v => u.Address.Postal.ToLower().StartsWith(v)));
                            break;
                    }
                }

                var users = await usersQuery.ToListAsync();

                // Filter by lead status/source via join to the Leads table
                if (leadStatusRule != null || leadSourceRule != null)
                {
                    var leadsFilterQuery = _context.Leads.Where(l => l.UserId != null && l.DeletedAt == null);
                    if (leadStatusRule != null)
                    {
                        var vals = leadStatusRule.Value.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim().ToLower()).Where(v => !string.IsNullOrEmpty(v)).ToList();
                        leadsFilterQuery = leadsFilterQuery.Where(l => vals.Contains(l.Status.ToLower()));
                    }
                    if (leadSourceRule != null)
                    {
                        var vals = leadSourceRule.Value.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim().ToLower()).Where(v => !string.IsNullOrEmpty(v)).ToList();
                        leadsFilterQuery = leadsFilterQuery.Where(l => vals.Contains(l.Source.ToLower()));
                    }
                    var linkedUserIds = await leadsFilterQuery.Select(l => l.UserId!.Value).ToListAsync();
                    users = users.Where(u => linkedUserIds.Contains(u.Id)).ToList();
                }

                results.AddRange(users.Select(u => ((int?)u.Id, u.Email, u.FirstName, u.LastName)));
            }

            // ── Pool 2: unregistered leads (UserId == null) ───────────────────
            if (includeUnregistered)
            {
                var leadsQuery = _context.Leads
                    .Where(l => l.UserId == null && l.DeletedAt == null)
                    .AsQueryable();

                if (leadStatusRule != null)
                {
                    var vals = leadStatusRule.Value.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim().ToLower()).Where(v => !string.IsNullOrEmpty(v)).ToList();
                    leadsQuery = leadsQuery.Where(l => vals.Contains(l.Status.ToLower()));
                }
                if (leadSourceRule != null)
                {
                    var vals = leadSourceRule.Value.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim().ToLower()).Where(v => !string.IsNullOrEmpty(v)).ToList();
                    leadsQuery = leadsQuery.Where(l => vals.Contains(l.Source.ToLower()));
                }

                var unregisteredLeads = await leadsQuery.ToListAsync();
                results.AddRange(unregisteredLeads.Select(l => ((int?)null, l.Email, l.FirstName, l.LastName)));
            }

            // Deduplicate by email
            return results
                .Where(r => !string.IsNullOrWhiteSpace(r.Email))
                .GroupBy(r => r.Email.ToLower())
                .Select(g => g.First())
                .ToList();
        }

        public async Task<SegmentPreviewDto> PreviewAsync(int segmentId)
        {
            var results = await EvaluateAsync(segmentId);
            return new SegmentPreviewDto
            {
                Count = results.Count,
                SampleEmails = results.Take(5).Select(r => r.Email).ToList()
            };
        }
    }

    // Internal rule model for JSON deserialization (case-insensitive)
    internal class SegmentRule
    {
        public string Field { get; set; } = string.Empty;
        public string Operator { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
