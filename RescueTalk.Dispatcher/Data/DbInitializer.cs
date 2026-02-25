using RescueTalk.Dispatcher.Models;

namespace RescueTalk.Dispatcher.Data
{
    public class DbInitializer
    {
        public static void Seed(RescueTalkDbContext context)
        {
            // 1. Сийдване на линейки 
            if (!context.Ambulances.Any())
            {
                var ambulances = new List<Ambulance>
                {
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Ivan Petrov", Latitude = 43.8365, Longitude = 25.9642, IsAvailable = true },
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Georgi Ivanov", Latitude = 43.8400, Longitude = 25.9500, IsAvailable = true },
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Petar Genchev", Latitude = 43.8280, Longitude = 25.9605, IsAvailable = true },
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Stamat Gerasimov", Latitude = 43.8420, Longitude = 25.9700, IsAvailable = true },
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Kaloyan Jordanov", Latitude = 43.8335, Longitude = 25.9580, IsAvailable = true },
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Vencislav Nikolaev", Latitude = 43.8385, Longitude = 25.9720, IsAvailable = true },
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Bojidar Minkov", Latitude = 43.8300, Longitude = 25.9670, IsAvailable = true },
                    new Ambulance { Id = Guid.NewGuid(), DriverName = "Konstantin Kostov", Latitude = 43.8504, Longitude = 25.9914, IsAvailable = true }
                };
                context.Ambulances.AddRange(ambulances);
            }

            // 2. Сийдване на инцидент 
            if (!context.Incidents.Any())
            {
                context.Incidents.Add(new Incident
                {
                    Id = Guid.NewGuid(),
                    Code = "RT-SEED01",
                    Latitude = 43.84731203596243,
                    Longitude = 25.97731509849786,
                    Status = "Pending",
                    IsActive = true,
                });
            }

            context.SaveChanges();
        }
    }
}
