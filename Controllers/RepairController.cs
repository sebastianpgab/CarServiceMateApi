using CarServiceMate.Entities;
using CarServiceMate.Models;
using CarServiceMate.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Controllers
{
    [Route("api/vehicle/{vehicleId}/repair")]
    [ApiController]
    public class RepairController : ControllerBase
    {
        private readonly IRepairService _reapairService;

        public RepairController(IRepairService reapairService)
        {
            _reapairService = reapairService;
        }
        [HttpPost]
        public ActionResult<Repair> CreateRepair([FromBody] RepairDto repairDto)
        {
            var repair = _reapairService.CreateRepair(repairDto);
            return Ok(repair);
        }
        [HttpGet]
        public ActionResult<RepairDto> GetAll()
        {
           var repair = _reapairService.GetAll();
            return Ok(repair);
        }
    }
}
