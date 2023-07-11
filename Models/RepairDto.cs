using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Models
{
    public class RepairDto
    {
        public int Id { get; set; }
        public DateTime RepairDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
    }
}
