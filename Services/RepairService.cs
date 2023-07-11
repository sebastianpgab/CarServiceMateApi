using AutoMapper;
using CarServiceMate.Entities;
using CarServiceMate.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public interface IRepairService
    {
        public IEnumerable<RepairDto> GetAll();
        public Repair CreateRepair(RepairDto repairDto);
    }
    public class RepairService : IRepairService
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly IMapper _mapper;
        public RepairService(CarServiceMateDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<RepairDto> GetAll()
        {
            var repairs = _dbContext.Repairs.ToList();
            var reapirsDto = _mapper.Map<IEnumerable<RepairDto>>(repairs);
            //tu mi cos nie zwraca tego co chce
            return reapirsDto;
        }

        public Repair CreateRepair(RepairDto repairDto)
        {
            var repair = _mapper.Map<Repair>(repairDto);
            _dbContext.Repairs.Add(repair);
            _dbContext.SaveChanges();
            return repair;
        }

    }
}
