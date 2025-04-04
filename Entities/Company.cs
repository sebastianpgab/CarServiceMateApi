using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
        public bool hasSubscription { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<MailRequest> MailRequests { get; set; }
        public ICollection<SmsRequest> SmsRequests { get; set; }
    }
}
