using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Entities
{
    public class MailRequest
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Sender { get; set; } = "sebastianpgab@gmail.com";
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
