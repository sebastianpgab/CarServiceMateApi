﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public int IdCompany { get; set; } = 1;
        public Company Company { get; set; }

    }
}
