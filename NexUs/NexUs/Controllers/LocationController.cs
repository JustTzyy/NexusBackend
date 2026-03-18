using Microsoft.AspNetCore.Mvc;
using NexUs.Models.DTO.Common;
using NexUs.Services.Interfaces;

namespace NexUs.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        /// <summary>
        /// Get all Philippine regions
        /// </summary>
        [HttpGet("regions")]
        public ActionResult<ApiResponse<List<LocationDto>>> GetRegions()
        {
            var regions = _locationService.GetRegions()
                .Select(r => new LocationDto { Code = r.Code, Name = r.Name })
                .ToList();

            return Ok(ApiResponse<List<LocationDto>>.SuccessResponse(regions, "Regions retrieved successfully"));
        }

        /// <summary>
        /// Get provinces by region code
        /// </summary>
        [HttpGet("provinces/{regionCode}")]
        public ActionResult<ApiResponse<List<LocationDto>>> GetProvinces(string regionCode)
        {
            var provinces = _locationService.GetProvincesByRegion(regionCode)
                .Select(p => new LocationDto { Code = p.Code, Name = p.Name })
                .ToList();

            return Ok(ApiResponse<List<LocationDto>>.SuccessResponse(provinces, "Provinces retrieved successfully"));
        }

        /// <summary>
        /// Get cities/municipalities by province code
        /// </summary>
        [HttpGet("cities/{provinceCode}")]
        public ActionResult<ApiResponse<List<LocationDto>>> GetCities(string provinceCode)
        {
            var cities = _locationService.GetCitiesByProvince(provinceCode)
                .Select(c => new LocationDto { Code = c.Code, Name = c.Name })
                .ToList();

            return Ok(ApiResponse<List<LocationDto>>.SuccessResponse(cities, "Cities retrieved successfully"));
        }
    }

    public class LocationDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
