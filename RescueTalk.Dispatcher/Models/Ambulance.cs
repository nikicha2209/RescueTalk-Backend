namespace RescueTalk.Dispatcher.Models
{
    public class Ambulance
    {
        public Guid Id { get; set; }
        public string DriverName { get; set; }
        public bool IsAvailable { get; set; } = true;

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
