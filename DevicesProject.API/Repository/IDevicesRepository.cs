using DevicesProject.API.Dtos;
using DevicesProject.API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DevicesProject.API.Repository
{
    public interface IDevicesRepository
    {
        public Task<Guid> AddDeviceAsync(DeviceDto device);

        public Task<Device> GetDeviceByIdAsync(Guid id);

        public Task<List<Device>> GetDevicesAsync();

        public Task<List<Device>> GetDevicesByBrandAsync(string brand);

        public Task UpdateDeviceAsync(Guid id, DeviceDto device);

        public Task UpdateDevicePatchAsync(Guid id, JsonPatchDocument device);

        public Task DeleteDeviceAsync(Guid id);
    }
}
