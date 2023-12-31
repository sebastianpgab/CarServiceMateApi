﻿using System;

namespace CarServiceMate.Entities
{
    public class Repair
    {
        public int Id { get; set; }
        public DateTime RepairDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public int? OrderId { get; set; }
        public int IdCompany { get; set; }

    }
}