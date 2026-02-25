using System.ComponentModel.DataAnnotations;

namespace RescueTalk.Dispatcher.Models
{
    public class Incident
    {
        public Guid Id { get; set; }

        [Phone]
        public string? PatientPhone { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }

        public Guid? AmbulanceId { get; set; }
        public Ambulance? Ambulance { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";
    }
}
