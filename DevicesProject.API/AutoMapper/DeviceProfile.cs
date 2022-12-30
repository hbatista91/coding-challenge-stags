using AutoMapper;
using DevicesProject.API.Dtos;
using DevicesProject.API.Models;

namespace DevicesProject.API.AutoMapper
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceDto, Device>();
        }
    }
}
