using LeHanNhat_Lab2_CSE422.Models;

namespace LeHanNhat_Lab2_CSE422.Services
{
    public static class DataStore
    {
        public static List<DeviceCategory> Categories { get; set; } = new List<DeviceCategory>();
        public static List<Device> Devices { get; set; } = new List<Device>();
        public static List<User> Users { get; set; } = new List<User>();

        static DataStore()
        {
           
            Categories.Add(new DeviceCategory { Id = 1, Name = "Computer" });
            Categories.Add(new DeviceCategory { Id = 2, Name = "Printer" });
            Categories.Add(new DeviceCategory { Id = 3, Name = "Phone" });

            Devices.Add(new Device
            {
                Id = 1,
                Name = "Dell Laptop",
                Code = "DL001",
                CategoryId = 1,
                Status = DeviceStatus.InUse,
                EntryDate = DateTime.Now
            });
        }
    }
}
