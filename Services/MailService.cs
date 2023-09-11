using CarServiceMate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public interface IMailService
    {
        public Task<MailRequest> SendMail(MailRequest mailRequest);
    }
    public class MailService : IMailService
    {
        private readonly MailLogic _mailLogic;
        private readonly CarServiceMateDbContext _dbContext;
        public MailService(CarServiceMateDbContext dbContext, MailLogic mailLogic)
        {
            _dbContext = dbContext;
            _mailLogic = mailLogic;
        }


        public async Task<MailRequest> SendMail(MailRequest mailRequest)
        {
            var recipients = _dbContext.Clients.Select(p => p.Email).ToList();

            await _mailLogic.SendEmailAsync(recipients, mailRequest.Subject, mailRequest.Message);

            if(mailRequest is not null)
            {
                _dbContext.Add(mailRequest);
                _dbContext.SaveChanges();
                return mailRequest;
            }
            return mailRequest;

        }
    }


}
