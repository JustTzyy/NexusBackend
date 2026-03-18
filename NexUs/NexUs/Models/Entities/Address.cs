namespace NexUs.Models.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetBarangay { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string CityMunicipality { get; set; } = string.Empty;
        public string Postal { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}