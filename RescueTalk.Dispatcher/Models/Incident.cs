namespace RescueTalk.Dispatcher.Models
{
    public class Incident
    {
        public Guid Id { get; set; }

        public string? PatientPhone { get; set; }
        public string? Code { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid? AmbulanceId { get; set; }
        public Ambulance? Ambulance { get; set; }

        public bool IsActive { get; set; } = true;
        public string Status { get; set; } = "Pending";
    }
}
