using AutoMapper;
using CarServiceMate.Entities;
using CarServiceMate.Models;
using CarServiceMate.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarServiceMate.Controllers
{
    [Route("api/vehicle")]
    [ApiController]  //Validation during etc. create new object will be wrong => return BadRequest (It will work when you set validation on the property in the entity.)
    public class VehicleController : ControllerBase
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly IMapper _autoMapper;
        private readonly IVehicleService _vehicleService;
        public VehicleController(CarServiceMateDbContext dbContext, IMapper autoMapper, IVehicleService vehicleService)
        {
            _dbContext = dbContext;
            _autoMapper = autoMapper;
            _vehicleService = vehicleService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromQuery] string marke, [FromQuery] string model, [FromQuery] int? year)
        {
           var idVehcile = _vehicleService.Update(id, marke, model, year, User);
            return Ok($"Vehicle {id} has been updated");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var idVehicle = _vehicleService.Delete(id, User);
            return Ok($"Vehcile {id} has been deleted");
        }

        [HttpGet]
        public ActionResult<IEnumerable<VehicleDto>> GetAll()
        {
            var vehicles = _vehicleService.GetAll();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleDto> Get([FromRoute] int id)
        {
            var vehicle = _vehicleService.GetById(id);
            return Ok(vehicle);
        }

        [HttpPost("{clientId}")] 
        public ActionResult CreateVehicle([FromBody] VehicleDto vehicleDto, [FromRoute] int clientId)
        {
            //var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var client = _vehicleService.FindClient(clientId);
            var id = _vehicleService.CreateVehicle(vehicleDto, client.Id);
            return Created($"/api/vehicle/{id}", null);
        }
        
        [HttpGet("vin/{searchedVin}")]
        public async Task<ActionResult> SearchVin([FromRoute] string searchedVin)
        {
            var foundVehicle = await _vehicleService.SearchVin(searchedVin);
            if(foundVehicle is not null)
            {
                return Ok(foundVehicle);
            }
            return NotFound();
        }



    }
}
