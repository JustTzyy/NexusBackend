using NexUs.Models.DTO.Common;

namespace NexUs.Services.Interfaces
{
    public interface IAddressService
    {
        Task<int> CreateAddressAsync(CreateAddressDto dto);
    }
}
