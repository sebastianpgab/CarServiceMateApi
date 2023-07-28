using CarServiceMate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public interface ISmsService
    {
        public Task<SmsRequest> SendSms(int vehicleId);
    }
    public class SmsService : ISmsService
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly SmsLogic _smsLogic;
        private readonly IClientService _clientService;
        private readonly IVehicleService _vehicleService;
        private readonly ILogger<SmsService> _logger;

        public SmsService(CarServiceMateDbContext dbContext, SmsLogic smsLogic, ILogger<SmsService> logger,
            IClientService clientService, IVehicleService vehicleService)
        {
            _dbContext = dbContext;
            _smsLogic = smsLogic;
            _logger = logger;
            _clientService = clientService;
            _vehicleService = vehicleService;
        }

        public async Task<SmsRequest> SendSms(int vehicleId)
        {
            var client = _clientService.GetClientByVehicleId(vehicleId);
            var vehicle = _vehicleService.GetById(vehicleId);

            if (client is not null)
            {
                var smsRequest = new SmsRequest
                {
                    Message = $"{client.FirstName}, Twój pojazd jest na etapie {vehicle.Status}",
                    RecipientPhoneNumber = client.PhoneNumber
                };

                _dbContext.SmsRequests.Add(smsRequest);
                await _dbContext.SaveChangesAsync();

                await _smsLogic.SendSmsAsync(smsRequest.RecipientPhoneNumber, smsRequest.Message);
                return smsRequest;
            }
            throw new NullReferenceException("Client is null");
        }
    }
}

