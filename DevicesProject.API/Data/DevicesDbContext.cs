using DevicesProject.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevicesProject.API.Data
{
    public class DevicesDbContext : IdentityDbContext
    {
        public DevicesDbContext(DbContextOptions<DevicesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
    }
}
