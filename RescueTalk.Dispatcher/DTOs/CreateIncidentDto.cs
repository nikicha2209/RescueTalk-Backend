using System.ComponentModel.DataAnnotations;

namespace RescueTalk.Dispatcher.DTOs
{
    public class CreateIncidentDto
    {
        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public double Longitude { get; set; }

        [Phone]
        public string? PatientPhone { get; set; }
    }
}