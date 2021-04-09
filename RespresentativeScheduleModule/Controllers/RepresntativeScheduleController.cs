using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespresentativeScheduleModule.Models;
using RespresentativeScheduleModule.ServicesProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RepresntativeScheduleController : ControllerBase
    {
        private readonly IRepresentativeScheduleService _repscheduleservice;
        

        public RepresntativeScheduleController(IRepresentativeScheduleService repscheduleservice)
        {
            _repscheduleservice = repscheduleservice;
            
        }
        [HttpGet("GetSchedule")]
        public async Task<ActionResult> Get(string startdate)
        {
            try
            {
                DateTime date = Convert.ToDateTime(startdate);
               var result=await _repscheduleservice.GetSchedule(date);
                if (result != null || result.Count != 0)
                    return new OkObjectResult(result);
                else
                    return NotFound("schedule not found");
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
        
    }
}
