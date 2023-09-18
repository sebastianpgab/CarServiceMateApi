using AutoMapper;
using CarServiceMate.Entities;
using CarServiceMate.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public interface IRepairService
    {
        public IEnumerable<RepairDto> GetAll(int vehicleId);
        public RepairDto Update(int id, Repair updatedRepiar);
        public RepairDto GetRepair(int id);
        public Repair CreateRepair(Repair repairDto);
        public Repair GetRepairByVehicleId(int id);
        public IEnumerable<Repair> SearchRepairByDate(int id, DateTime startDate, DateTime endDate);
        public IEnumerable<Repair> GetAllVehiclesRepairedByMonth();


    }
    public class RepairService : IRepairService
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserClaimsService _userClaimsService;

        public RepairService(CarServiceMateDbContext dbContext, IMapper mapper, UserClaimsService userClaimsService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userClaimsService = userClaimsService;
        }

        public IEnumerable<RepairDto> GetAll(int vehicleId)
        {
            var repairs = _dbContext.Repairs.Where(p => p.VehicleId == vehicleId && p.IdCompany == _userClaimsService.companyId).ToList();
            var reapirsDto = _mapper.Map<IEnumerable<RepairDto>>(repairs);
            return reapirsDto;
        }

        public Repair CreateRepair(Repair repair)
        {
            if(repair is not null)
            {
                repair.IdCompany = _userClaimsService.companyId;
                _dbContext.Repairs.Add(repair);
                _dbContext.SaveChanges();
                return repair;
            }
            throw new NullReferenceException();

        }

        public RepairDto GetRepair(int id)
        {
            var repair = _dbContext.Repairs.FirstOrDefault(p => p.Id == id && p.IdCompany == _userClaimsService.companyId);
            var repairDto = _mapper.Map<RepairDto>(repair);
            return repairDto;
        }

        public Repair GetRepairByVehicleId(int id)
        {
            var repair = _dbContext.Repairs.Where(c => c.VehicleId == id && c.IdCompany == _userClaimsService.companyId).OrderByDescending(p => p.Id).FirstOrDefault();
            return repair;
        }

        public RepairDto Update(int id, Repair updatedRepiar)
        {
            var repair = _dbContext.Repairs.FirstOrDefault(p => p.Id == id && p.IdCompany == _userClaimsService.companyId);
            repair.Description = updatedRepiar.Description != repair.Description ? updatedRepiar.Description : repair.Description;
            repair.Cost = updatedRepiar.Cost != repair.Cost ? updatedRepiar.Cost : repair.Cost;
            repair.RepairDate = updatedRepiar.RepairDate != repair.RepairDate &&
                updatedRepiar.RepairDate != DateTime.MinValue ? updatedRepiar.RepairDate : repair.RepairDate;
            _dbContext.SaveChanges();

            var repairDto = _mapper.Map<RepairDto>(repair);
            return repairDto;
        }
        public IEnumerable<Repair> SearchRepairByDate(int id, DateTime startDate, DateTime endDate)
        {
            var repairs = _dbContext.Repairs.Where(p => p.VehicleId == id && p.IdCompany == _userClaimsService.companyId);
            var newRepairs = new List<Repair>();
            foreach(var repair in repairs)
            {
                if(startDate < repair.RepairDate && endDate > repair.RepairDate)
                {
                    newRepairs.Add(repair);
                }
            }
            return newRepairs;
        }

        public IEnumerable<Repair> GetAllVehiclesRepairedByMonth()
        {
            var currentDate = DateTime.Today;
            var dateOfLastMonth = currentDate.AddMonths(-1);
            var vehiclesRepaired = _dbContext.Repairs.Where(p => p.RepairDate > dateOfLastMonth && p.IdCompany == _userClaimsService.companyId);
            return vehiclesRepaired;
        }

    }
}
