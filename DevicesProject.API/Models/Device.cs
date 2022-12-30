namespace DevicesProject.API.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
