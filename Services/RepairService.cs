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
        public IEnumerable<RepairDto> GetAll(int vehicleId);
        public RepairDto Update(int id, Repair updatedRepiar);
        public RepairDto GetRepair(int id);
        public Repair CreateRepair(int vehicleId, RepairDto repairDto);
        public Repair GetRepairByVehicleId(int id);
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

        public IEnumerable<RepairDto> GetAll(int vehicleId)
        {
            var repairs = _dbContext.Repairs.Where(p => p.VehicleId == vehicleId).ToList();
            var reapirsDto = _mapper.Map<IEnumerable<RepairDto>>(repairs);
            return reapirsDto;
        }

        public Repair CreateRepair(int vehicleId, RepairDto repairDto)
        {
            var repair = _mapper.Map<Repair>(repairDto);
            repair.VehicleId = vehicleId;
            _dbContext.Repairs.Add(repair);
            _dbContext.SaveChanges();
            return repair;
        }

        public RepairDto GetRepair(int id)
        {
            var repair = _dbContext.Repairs.FirstOrDefault(p => p.Id == id);
            var repairDto = _mapper.Map<RepairDto>(repair);
            return repairDto;
        }

        public Repair GetRepairByVehicleId(int id)
        {
            var repair = _dbContext.Repairs.Where(c => c.VehicleId == id).OrderByDescending(p => p.Id).FirstOrDefault();
            return repair;
        }

        public RepairDto Update(int id, Repair updatedRepiar)
        {
            var repair = _dbContext.Repairs.FirstOrDefault(p => p.Id == id);
            repair.Description = updatedRepiar.Description != repair.Description ? updatedRepiar.Description : repair.Description;
            repair.Cost = updatedRepiar.Cost != repair.Cost ? updatedRepiar.Cost : repair.Cost;
            repair.RepairDate = updatedRepiar.RepairDate != repair.RepairDate &&
                updatedRepiar.RepairDate != DateTime.MinValue ? updatedRepiar.RepairDate : repair.RepairDate;
            _dbContext.SaveChanges();

            var repairDto = _mapper.Map<RepairDto>(repair);
            return repairDto;
        }

    }
}
