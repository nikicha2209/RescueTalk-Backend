namespace RescueTalk.Dispatcher.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Ambulance
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string DriverName { get; set; }

        public bool IsAvailable { get; set; } = true;

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longitude { get; set; }

    }
}
