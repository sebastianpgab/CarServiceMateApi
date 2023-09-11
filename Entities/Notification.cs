using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime NotificationDate { get; set; }
        public string Description { get; set; }

        public virtual Repair Repair { get; set; }
        public int IdCompany { get; set; }

    }
}
