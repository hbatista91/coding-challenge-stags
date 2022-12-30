using AutoMapper;
using DevicesProject.API.Data;
using DevicesProject.API.Dtos;
using DevicesProject.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace DevicesProject.API.Repository
{
    public class DevicesRepository : IDevicesRepository
    {
        private readonly DevicesDbContext _context;
        private readonly IMapper _mapper;

        public DevicesRepository(IMapper mapper, DevicesDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> AddDeviceAsync(DeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            device.CreatedDate = DateTime.UtcNow;

            _context.Add(device);
            await _context.SaveChangesAsync();

            return device.Id;
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            var device = new Device { Id = id };

            _context.Devices.Remove(device);

            await _context.SaveChangesAsync();
        }

        public async Task<Device> GetDeviceByIdAsync(Guid id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task<List<Device>> GetDevicesAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<List<Device>> GetDevicesByBrandAsync(string brand)
        {
            return await _context.Devices.Where(x => x.Brand == brand).ToListAsync();
        }

        public async Task UpdateDeviceAsync(Guid id, DeviceDto deviceDto)
        {
            var device = _mapper.Map<Device>(deviceDto);
            device.Id = id;

            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDevicePatchAsync(Guid id, JsonPatchDocument devicePatch)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                devicePatch.ApplyTo(device);
                await _context.SaveChangesAsync();
            }
        }
    }
}
