using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class LocationService : ILocationService
    {
        private static readonly Dictionary<string, string> Regions = new()
        {
            { "01", "Region I - Ilocos Region" },
            { "02", "Region II - Cagayan Valley" },
            { "03", "Region III - Central Luzon" },
            { "04A", "Region IV-A - CALABARZON" },
            { "04B", "Region IV-B - MIMAROPA" },
            { "05", "Region V - Bicol Region" },
            { "06", "Region VI - Western Visayas" },
            { "07", "Region VII - Central Visayas" },
            { "08", "Region VIII - Eastern Visayas" },
            { "09", "Region IX - Zamboanga Peninsula" },
            { "10", "Region X - Northern Mindanao" },
            { "11", "Region XI - Davao Region" },
            { "12", "Region XII - SOCCSKSARGEN" },
            { "13", "NCR - National Capital Region" },
            { "14", "CAR - Cordillera Administrative Region" },
            { "15", "BARMM - Bangsamoro Autonomous Region in Muslim Mindanao" },
            { "16", "Region XIII - Caraga" }
        };

        private static readonly Dictionary<string, Dictionary<string, string>> Provinces = new()
        {
            ["13"] = new() { { "1374", "Metro Manila" } },
            ["03"] = new()
            {
                { "0308", "Bataan" }, { "0314", "Bulacan" }, { "0349", "Nueva Ecija" },
                { "0354", "Pampanga" }, { "0369", "Tarlac" }, { "0377", "Zambales" }, { "0371", "Aurora" }
            },
            ["04A"] = new()
            {
                { "0410", "Batangas" }, { "0421", "Cavite" }, { "0434", "Laguna" },
                { "0456", "Quezon" }, { "0458", "Rizal" }
            },
            ["07"] = new()
            {
                { "0712", "Bohol" }, { "0722", "Cebu" }, { "0746", "Negros Oriental" }, { "0761", "Siquijor" }
            },
            ["11"] = new()
            {
                { "1123", "Davao del Norte" }, { "1124", "Davao del Sur" }, { "1125", "Davao Oriental" },
                { "1182", "Davao de Oro" }, { "1186", "Davao Occidental" }
            }
        };

        private static readonly Dictionary<string, Dictionary<string, string>> Cities = new()
        {
            ["1374"] = new()
            {
                { "137401", "Manila" }, { "137402", "Mandaluyong" }, { "137403", "Marikina" },
                { "137404", "Pasig" }, { "137405", "Quezon City" }, { "137406", "San Juan" },
                { "137407", "Caloocan" }, { "137408", "Malabon" }, { "137409", "Navotas" },
                { "137410", "Valenzuela" }, { "137411", "Las Piñas" }, { "137412", "Makati" },
                { "137413", "Muntinlupa" }, { "137414", "Parañaque" }, { "137415", "Pasay" },
                { "137416", "Pateros" }, { "137417", "Taguig" }
            },
            ["0722"] = new()
            {
                { "072201", "Cebu City" }, { "072202", "Mandaue City" }, { "072203", "Lapu-Lapu City" },
                { "072204", "Talisay City" }, { "072205", "Toledo City" }, { "072206", "Danao City" },
                { "072207", "Carcar City" }
            },
            ["1123"] = new()
            {
                { "112301", "Tagum City" }, { "112302", "Panabo City" }, { "112303", "Samal City" },
                { "112304", "Asuncion" }, { "112305", "Kapalong" }
            },
            ["1124"] = new()
            {
                { "112401", "Davao City" }, { "112402", "Digos City" }, { "112403", "Bansalan" },
                { "112404", "Hagonoy" }, { "112405", "Magsaysay" }
            }
        };

        // Flattened lookups for resolve methods
        private static readonly Dictionary<string, string> AllProvinces;
        private static readonly Dictionary<string, string> AllCities;

        static LocationService()
        {
            AllProvinces = new Dictionary<string, string>();
            foreach (var region in Provinces.Values)
                foreach (var kvp in region)
                    AllProvinces[kvp.Key] = kvp.Value;

            AllCities = new Dictionary<string, string>();
            foreach (var province in Cities.Values)
                foreach (var kvp in province)
                    AllCities[kvp.Key] = kvp.Value;
        }

        public List<LocationItem> GetRegions()
        {
            return Regions.Select(r => new LocationItem { Code = r.Key, Name = r.Value }).ToList();
        }

        public List<LocationItem> GetProvincesByRegion(string regionCode)
        {
            if (Provinces.TryGetValue(regionCode, out var provinces))
                return provinces.Select(p => new LocationItem { Code = p.Key, Name = p.Value }).ToList();
            return new List<LocationItem>();
        }

        public List<LocationItem> GetCitiesByProvince(string provinceCode)
        {
            if (Cities.TryGetValue(provinceCode, out var cities))
                return cities.Select(c => new LocationItem { Code = c.Key, Name = c.Value }).ToList();
            return new List<LocationItem>();
        }

        public string ResolveRegionName(string code)
        {
            if (string.IsNullOrEmpty(code)) return code;
            return Regions.TryGetValue(code, out var name) ? name : code;
        }

        public string ResolveProvinceName(string code)
        {
            if (string.IsNullOrEmpty(code)) return code;
            return AllProvinces.TryGetValue(code, out var name) ? name : code;
        }

        public string ResolveCityName(string code)
        {
            if (string.IsNullOrEmpty(code)) return code;
            return AllCities.TryGetValue(code, out var name) ? name : code;
        }
    }
}
