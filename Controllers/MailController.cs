using CarServiceMate.Entities;
using CarServiceMate.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Controllers
{
    [Route("api/send")]
    [ApiController]
    public class MailController : Controller
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("mail")]
        public async Task<IActionResult> SendMail([FromBody] MailRequest mailRequest)
        {
            var response = await _mailService.SendMail(mailRequest);
            return Ok(response);
        }



    }
}
