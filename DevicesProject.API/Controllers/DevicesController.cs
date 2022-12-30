using DevicesProject.API.Dtos;
using DevicesProject.API.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DevicesProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesRepository _devicesRepository;

        public DevicesController(IDevicesRepository devicesRepository)
        {
            _devicesRepository = devicesRepository;
        }

        [HttpPost(Name = "AddDevice")]
        public async Task<IActionResult> Add([FromBody] DeviceDto device)
        {
            var id = await _devicesRepository.AddDeviceAsync(device);
            return CreatedAtAction(nameof(GetById), new { id, controller = "devices" }, id);
        }

        [HttpGet("{id}", Name = "GetDeviceById")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var device = await _devicesRepository.GetDeviceByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        [HttpGet("", Name = "GetDevices")]
        public async Task<IActionResult> Get()
        {
            var devices = await _devicesRepository.GetDevicesAsync();
            if (!devices.Any())
            {
                return NoContent();
            }

            return Ok(devices);
        }

        [HttpGet("brand/{brand}", Name = "GetDevicesByBrand")]
        public async Task<IActionResult> GetByBrand([FromRoute] string brand)
        {
            var devices = await _devicesRepository.GetDevicesByBrandAsync(brand);
            if (!devices.Any())
            {
                return NoContent();
            }

            return Ok(devices);
        }

        [HttpPut("{id}", Name = "UpdateDeviceFull")]
        public async Task<IActionResult> UpdateFull([FromBody] DeviceDto device, [FromRoute] Guid id)
        {
            await _devicesRepository.UpdateDeviceAsync(id, device);
            return Ok();
        }

        [HttpPatch("{id}", Name = "UpdateDevicePartial")]
        public async Task<IActionResult> UpdatePartial([FromBody] JsonPatchDocument device, [FromRoute] Guid id)
        {
            await _devicesRepository.UpdateDevicePatchAsync(id, device);
            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteDevice")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _devicesRepository.DeleteDeviceAsync(id);
            return Ok();
        }
    }
}
