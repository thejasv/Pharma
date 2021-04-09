using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMedicineSupplyService.Models;
using PharmacyMedicineSupplyService.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PharmacySupplyController : ControllerBase
    {
        private readonly IPharmacySupplyProvider _supplyprovider;

        public PharmacySupplyController(IPharmacySupplyProvider supplyprovider)
        {
            _supplyprovider = supplyprovider;
        }
        [HttpPost("demand")]
        public async Task<IActionResult> Get([FromBody] List<MedicineDemand> medicinedemand)
        {
            try
            {
                var res = await _supplyprovider.GetSupply(medicinedemand);
                if (res.Count() > 0)
                {
                    return Ok(res);
                }

                return NotFound("No such details found please try again.");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }
    }
}
