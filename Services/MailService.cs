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
        private readonly UserClaimsService _userClaimsService;

        public MailService(CarServiceMateDbContext dbContext, MailLogic mailLogic, UserClaimsService userClaimsService)
        {
            _dbContext = dbContext;
            _mailLogic = mailLogic;
            _userClaimsService = userClaimsService;
        }

        public async Task<MailRequest> SendMail(MailRequest mailRequest)
        {
            var recipients = _dbContext.Clients.Where(p => p.IdCompany == _userClaimsService.companyId).Select(p => p.Email).ToList();

            await _mailLogic.SendEmailAsync(recipients, mailRequest.Subject, mailRequest.Message);

            if(mailRequest is not null)
            {
                mailRequest.IdCompany = _userClaimsService.companyId;
                _dbContext.Add(mailRequest);
                _dbContext.SaveChanges();
                return mailRequest;
            }
            return mailRequest;

        }
    }


}
