namespace NexUs.Models.DTO.Common
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string StreetBarangay { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string CityMunicipality { get; set; } = string.Empty;
        public string Postal { get; set; } = string.Empty;
    }
}
