namespace NexUs.Models.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        
        // Foreign Keys
        public int? ManagedBy { get; set; }
        public int? AddressId { get; set; }
        
        // Navigation Properties
        public User? Manager { get; set; }
        public Address? Address { get; set; }
    }
}
