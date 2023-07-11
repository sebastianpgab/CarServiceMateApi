using CarServiceMate.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public interface ISmsService
    {
        public Task<SmsRequest> SendSms(SmsRequest smsRequest);

    }
    public class SmsService : ISmsService
    {
        private readonly CarServiceMateDbContext _dbContext;
        private readonly SmsLogic _smsLogic;
        private readonly ILogger<SmsService> _logger;
        public SmsService(CarServiceMateDbContext dbContext, SmsLogic smsLogic, ILogger<SmsService> logger)
        {
            _dbContext = dbContext;
            _smsLogic = smsLogic;
            _logger = logger;
        }
        public async Task<SmsRequest> SendSms(SmsRequest smsRequest)
        {
            if(smsRequest is not null)
            {
                _dbContext.SmsRequests.Add(smsRequest);
                _dbContext.SaveChanges();
                await _smsLogic.SendSmsAsync(smsRequest.RecipientPhoneNumber, smsRequest.Message);
                return smsRequest;
            }
            throw new NullReferenceException();
        }

    }
}
