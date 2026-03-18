namespace NexUs.Services.Interfaces
{
    public interface ILocationService
    {
        List<LocationItem> GetRegions();
        List<LocationItem> GetProvincesByRegion(string regionCode);
        List<LocationItem> GetCitiesByProvince(string provinceCode);
        string ResolveRegionName(string code);
        string ResolveProvinceName(string code);
        string ResolveCityName(string code);
    }

    public class LocationItem
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
