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
            CreateMap<Notification, NotificationDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Repair, RepairDto>();
            CreateMap<RepairDto, Repair>();
            CreateMap<ClientDto, Client>(); 
            /*CreateMap<Repair, RepairAllInformationDto>()
                .ForMember(m => m.Id, c => c.MapFrom(s => s.Id))
                .ForMember(m => m.RepairDate, c => c.MapFrom(s => s.RepairDate))
                .ForMember(m => m.Cost, c => c.MapFrom(s => s.Cost))
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Description))
                .ForPath(m => m.orderDto.OrderDate, c => c.MapFrom(s => s.Order.OrderDate))
                .ForPath(m => m.orderDto.TotalCost, c => c.MapFrom(s => s.Order.TotalCost))
                .ForPath(m => m.orderDto.Status, c => c.MapFrom(s => s.Order.Status))
                .ForPath(m => m.notificationDto.Description, c => c.MapFrom(s => s.Notification.Description))
                .ForPath(m => m.notificationDto.NotificationDate, c => c.MapFrom(s => s.Notification.NotificationDate));*/
        }
    }
}
