using CarServiceMate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public interface ISmsService
    {
        public Task<SmsRequest> SendSms(int vehicleId, ClaimsPrincipal user);    
    }
    public class SmsService : ISmsService
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly SmsLogic _smsLogic;
        private readonly IClientService _clientService;
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<SmsService> _logger;
        private readonly IRepairService _repairService;

        public SmsService(CarServiceMateDbContext dbContext, SmsLogic smsLogic, ILogger<SmsService> logger,
            IClientService clientService, IVehicleService vehicleService, IRepairService repairService)
        {
            _dbContext = dbContext;
            _smsLogic = smsLogic;
            _logger = logger;
            _clientService = clientService;
            _vehicleService = vehicleService;
            _repairService = repairService;
        }

        public async Task<SmsRequest> SendSms(int vehicleId, ClaimsPrincipal user)
        {
            var client = _clientService.GetClientByVehicleId(vehicleId);
            var vehicle = _vehicleService.GetById(vehicleId, user);
            var repair = _repairService.GetRepairByVehicleId(vehicle.Id);

            if (client is not null)
            {
                var smsRequest = new SmsRequest
                {
                    Message = $"{client.FirstName}, Twój pojazd jest na etapie: {vehicle.Status}. " +
                    $"Opis wykonywanych prac: {repair.Description}",
                    RecipientPhoneNumber = client.PhoneNumber
                };

                _dbContext.SmsRequests.Add(smsRequest);
                await _dbContext.SaveChangesAsync();

                try
                {
                    await _smsLogic.SendSmsAsync(smsRequest.RecipientPhoneNumber, smsRequest.Message);
                }
                catch (Exception ex)
                {
                    //loguj lub przetwarzaj zgłoszony wyjątek tutaj
                    //problem jest z autentykacja twilio
                    Console.WriteLine(ex);
                }
                return smsRequest;
            }
            throw new NullReferenceException("Client is null");
        }
    }
}

