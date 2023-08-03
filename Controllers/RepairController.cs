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
        public ActionResult<Repair> CreateRepair([FromRoute] int vehicleId, [FromBody] RepairDto repairDto)
        {
            var repair = _reapairService.CreateRepair(vehicleId, repairDto);
            return Ok(repair);
        }
        [HttpGet]
        public ActionResult<RepairDto> GetAll([FromRoute] int vehicleId)
        {
            var repairs = _reapairService.GetAll(vehicleId);
            return Ok(repairs);
        }

        [HttpGet("{repairId}")]
        public ActionResult<RepairDto> GetRepair([FromRoute] int repairId)
        {
            var reapir = _reapairService.GetRepair(repairId);
            return Ok(reapir);
        }

        [HttpPut("{repairId}")]
        public ActionResult<RepairDto> Update([FromRoute] int repairId, [FromBody] Repair updatedRepiar)
        {
            var reapir = _reapairService.Update(repairId, updatedRepiar);
            return Ok(reapir);
        }
    }
}
