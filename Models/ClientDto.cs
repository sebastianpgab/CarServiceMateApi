using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
