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
    public class SmsController : Controller
    {
        private readonly ISmsService _smsService;

        public SmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("sms")]
        public ActionResult SendSms([FromBody]int idVehicle)
        {
            var sms = _smsService.SendSms(idVehicle);
            return Ok(sms);
        }
    }
}
