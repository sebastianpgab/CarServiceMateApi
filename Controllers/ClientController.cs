using AutoMapper;
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
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IClientService _clientService;
        public ClientController(CarServiceMateDbContext dbContext, IMapper mapper, IClientService clientService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> GetAll()
        {
            var clients = _clientService.GetAll();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public ActionResult<ClientDto> Get([FromRoute] int id)
        {
            var client = _clientService.GetById(id);
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _clientService.Delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromRoute] int id, [FromBody] ClientDto clientDto)
        {
            _clientService.Update(id, clientDto);
            return Ok();
        }
        [HttpPost]
        public ActionResult Add([FromBody] ClientDto clientDto)
        {
            _clientService.Add(clientDto);
            return Ok();
        }
    }
}
