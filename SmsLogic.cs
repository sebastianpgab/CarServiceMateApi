using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CarServiceMate
{
    public class SmsLogic
    {
        private readonly string accountSid;
        private readonly string authToken;
        private readonly string twilioPhoneNumber;

        public SmsLogic(string accountSid, string authToken, string twilioPhoneNumber)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
            this.twilioPhoneNumber = twilioPhoneNumber;

            TwilioClient.Init(accountSid, authToken);
        }

        public async Task SendSmsAsync(string recipientPhoneNumber, string message)
        {
            var to = new PhoneNumber(recipientPhoneNumber);
            var from = new PhoneNumber(twilioPhoneNumber);

            await MessageResource.CreateAsync(
                to: to,
                from: from,
                body: message
            );
        }
    }
}
