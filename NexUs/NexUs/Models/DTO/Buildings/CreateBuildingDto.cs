using System.ComponentModel.DataAnnotations;
using NexUs.Models.DTO.Common;

namespace NexUs.Models.DTO.Buildings
{
    public class CreateBuildingDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int? ManagedBy { get; set; }

        [Required(ErrorMessage = "Address is required for buildings.")]
        public CreateAddressDto Address { get; set; } = null!;
    }
}
