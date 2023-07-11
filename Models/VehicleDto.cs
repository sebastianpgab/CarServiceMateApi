using System.ComponentModel.DataAnnotations;

namespace CarServiceMate.Models
{
    public class VehicleDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Make { get; set; }
        [Required]
        [MaxLength(25)]
        public string Model { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }
        [Required]
        [RegularExpression("^[0-9]{4}$")]
        public int Year { get; set; }
        public string Engine { get; set; }
        public int Kilometers { get; set; }
        public int? ClientId { get; set; }

    }
}