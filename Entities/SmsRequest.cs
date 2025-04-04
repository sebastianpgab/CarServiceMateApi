using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Entities
{
    public class SmsRequest
    {
        public int Id { get; set; }
        [Phone]
        public string RecipientPhoneNumber { get; set; }
        [Required]
        public string Message { get; set; }
        public int IdCompany { get; set; }
        public Company Company { get; set; }

    }
}
