using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NexUs.Models.DTO.Common
{
    public class CreateAddressDto
    {
        [JsonPropertyName("street")]
        public string Street { get; set; } = string.Empty;

        [JsonPropertyName("region")]
        public string Region { get; set; } = string.Empty;

        [JsonPropertyName("province")]
        public string Province { get; set; } = string.Empty;

        [Display(Name = "City/Municipality")]
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; } = string.Empty;
    }
}
