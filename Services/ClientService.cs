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
        public Client GetClientByVehicleId(int id);
        public IEnumerable<Client> searchByFullName(string name);
        public IEnumerable<Client> searchByPhoneNumber(string phoneNumber);
    }
    public class ClientService : IClientService
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserClaimsService _userClaimsService;
        public ClientService(CarServiceMateDbContext dbContext, IMapper mapper, UserClaimsService userClaimsService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userClaimsService = userClaimsService;
        }
        public IEnumerable<ClientDto> GetAll()
        {

            var clients = _dbContext.Clients.Where(p => p.IdCompany == _userClaimsService.companyId).ToList();
            if (clients.Any())
            {
                var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
                return clientsDto;
            }
            throw new NotFoundException("Clietns not found");
        }

        public ClientDto GetById(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(p => p.Id == id && p.IdCompany == _userClaimsService.companyId);
            if (client is not null)
            {
                var clientDto = _mapper.Map<ClientDto>(client);
                return clientDto;
            }
            throw new NotFoundException("Client not found");
        }

        public int Delete(int id)
        {
            var client = _dbContext.Clients.FirstOrDefault(p => p.Id == id && p.IdCompany == _userClaimsService.companyId);
            var vehicles = _dbContext.Vehicles.Where(p => p.ClientId == id && p.IdCompany == _userClaimsService.companyId);
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
            var client = _dbContext.Clients.FirstOrDefault(p => p.Id == id && p.IdCompany == _userClaimsService.companyId);
            if (client is not null)
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
            if( clientDto is not null) {

                var clinet = _mapper.Map<Client>(clientDto);
                clinet.IdCompany = _userClaimsService.companyId;
                _dbContext.Clients.Add(clinet);
                _dbContext.SaveChanges();
            }

        }

        public Client GetClientByVehicleId(int id)
        {
            var client = _dbContext.Vehicles.Where(c => id == c.Id && c.IdCompany == _userClaimsService.companyId).Select(v => v.Client).FirstOrDefault();
            return client;
        }

        public IEnumerable<Client> searchByFullName(string name)
        {
            var cleanedName = name.Trim().ToLower();
            var nameSegments = cleanedName.Split(' ', 2);

            var clients = _dbContext.Clients.Where(p => p.FirstName.ToLower() == nameSegments[0] && p.LastName.ToLower() == nameSegments[1] && p.IdCompany == _userClaimsService.companyId);
            if (clients.Any())
            {
                return clients;
            }
            throw new NotFoundException("Client not Found");
        }

        public IEnumerable<Client> searchByPhoneNumber(string phoneNumber)
        {
            var client = _dbContext.Clients.Where(p => p.PhoneNumber == phoneNumber && p.IdCompany == _userClaimsService.companyId);
            if (client.Any())
            {
                return client;
            }
            throw new NotFoundException("Client not Found");
        }
    }
}
