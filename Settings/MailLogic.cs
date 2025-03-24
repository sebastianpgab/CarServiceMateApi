namespace CarServiceMate.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http;
    using System.Text;
    using CarServiceMate.Settings;
    using Microsoft.Extensions.Options;

    public class MailLogic
    {
        private readonly MailgunSettings _maligunSettings;

        public MailLogic(IOptions<MailgunSettings> maligunSettings)
        {
            _maligunSettings = maligunSettings.Value;
        }

        public async Task SendEmailAsync(List<string> recipients, string subject, string message)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"api:{_maligunSettings.ApiKey}")));

                foreach (var recipient in recipients)
                {
                    var formData = new Dictionary<string, string>
                    {
                        { "from", "CarMate Info <postmaster@sandboxf5277ab396e5442682eded2fbddf3453.mailgun.org>" },
                        { "to", recipient },
                        { "subject", subject },
                        { "text", message }
                    };

                    var response = await client.PostAsync($"https://api.mailgun.net/v3/{_maligunSettings.Domain}/messages", new FormUrlEncodedContent(formData));
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        // Handle the error or throw an exception
                        throw new Exception($"Failed to send email: {responseContent}");
                    }
                }
            }
        }
    }
  


}
