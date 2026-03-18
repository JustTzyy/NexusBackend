using System.ComponentModel.DataAnnotations;
using NexUs.Models.DTO.Common;

namespace NexUs.Models.DTO.Buildings
{
    public class UpdateBuildingDto
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public int? ManagedBy { get; set; }
        public int? AddressId { get; set; }

        [Required(ErrorMessage = "Address is required for buildings.")]
        public CreateAddressDto Address { get; set; } = null!;
    }
}
