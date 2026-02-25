namespace RescueTalk.Dispatcher.DTOs
{
    public class AmbulanceResponseDto
    {
        public Guid Id { get; set; }
        public string DriverName { get; set; }
        public bool IsAvailable { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
