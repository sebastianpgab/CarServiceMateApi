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

        [HttpGet("{idVehicle}")]
        public ActionResult SendSms([FromRoute]int idVehicle)
        {
            var sms = _smsService.SendSms(idVehicle);
            return Ok(sms);
        }


        
    }
}
