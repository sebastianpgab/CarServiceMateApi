using AutoMapper;
using CarServiceMate.Entities;
using CarServiceMate.Exceptions;
using CarServiceMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public interface IClientService
    {
        public IEnumerable<ClientDto> GetAll();
        public ClientDto GetById(int id);
        public int Delete(int id);
        public bool Update(int id, ClientDto client);
        public void Add(ClientDto clientDto);

    }
    public class ClientService : IClientService
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly IMapper _mapper;
        public ClientService(CarServiceMateDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<ClientDto> GetAll()
        {
            var clients = _dbContext.Clients.ToList();
            if(clients is not null)
            {
                var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
                return clientsDto;
            }
            throw new NotFoundException("Clietns not found");
        }

        public ClientDto GetById(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(p => p.Id == id);
            if(client is not null)
            {
                var clientDto = _mapper.Map<ClientDto>(client);
                return clientDto;
            }
            throw new NotFoundException("Client not found");
        }

        public int Delete(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(p => p.Id == id);
            var vehicles = _dbContext.Vehicles.Where(p => p.ClientId == id);
            if (client is not null)
            {
                _dbContext.Vehicles.RemoveRange(vehicles);
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
                return client.Id;
            }
            throw new NotFoundException("Client not found");
        }

        public bool Update(int id, ClientDto clientDto)
        {
            var client = _dbContext.Clients.FirstOrDefault(p => p.Id == id);
            if(client is not null)
            {
                client.FirstName = clientDto.FirstName is not null ? clientDto.FirstName : client.FirstName;
                client.LastName = clientDto.LastName is not null ? clientDto.LastName : client.LastName;
                client.PhoneNumber = clientDto.PhoneNumber is not null ? clientDto.PhoneNumber : client.PhoneNumber;
                client.Email = clientDto.Email is not null ? clientDto.Email : client.Email;
                client.Address = clientDto.Address is not null ? clientDto.Address : client.Address;
                _dbContext.SaveChanges();
                return true;
            }
            throw new NotFoundException("Client not Found");
        }

        public void Add(ClientDto clientDto)
       {
            var clinet = _mapper.Map<Client>(clientDto);
            _dbContext.Clients.Add(clinet);
            _dbContext.SaveChanges();
        }
    }
}
