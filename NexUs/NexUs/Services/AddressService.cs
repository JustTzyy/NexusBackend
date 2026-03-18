using NexUs.Data;
using NexUs.Models.DTO.Common;
using NexUs.Models.Entities;
using NexUs.Services.Interfaces;

namespace NexUs.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAddressAsync(CreateAddressDto dto)
        {
            var address = new Address
            {
                StreetBarangay = dto.Street,
                Region = dto.Region,
                Province = dto.Province,
                CityMunicipality = dto.City,
                Postal = dto.PostalCode
            };

            // Check if address already exists (optional, but good practice to avoid dupes if desired)
            // However, business logic might allow same address for multiple users or just new entry.
            // For now, simple create.

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address.Id;
        }
    }
}
