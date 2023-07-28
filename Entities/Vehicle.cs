using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CarServiceMate.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public int? Year { get; set; }
        public string Engine { get; set; }
        public int Kilometers { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public int? ClientId { get; set; }
        public string Status { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Repair> Repairs { get; set; }
    }
}