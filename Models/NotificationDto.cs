using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Models
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public DateTime NotificationDate { get; set; }
        public string Description { get; set; }
    }
}
