using AutoMapper;
using CarServiceMate.Entities;
using CarServiceMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate
{
    public class CarServiceMateProfile : Profile
    {
        public CarServiceMateProfile()
        {
            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();
            CreateMap<Client, ClientDto>();
            CreateMap<Repair, RepairDto>();
            CreateMap<RepairDto, Repair>();
            CreateMap<ClientDto, Client>(); 
        }
    }
}
