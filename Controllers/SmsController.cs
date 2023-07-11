using CarServiceMate.Entities;
using CarServiceMate.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMate.Controllers
{
    [Route("api/sms")]
    [ApiController]
    public class SmsController : Controller
    {
        private readonly ISmsService _smsService;

        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost]
        public ActionResult SendSms([FromBody] SmsRequest smsRequest)
        {
            var sms = _smsService.SendSms(smsRequest);
            return Ok(sms);
        }
    }
}
