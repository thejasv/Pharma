using MedicineStockProject.Models;
using MedicineStockProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicineStockProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {

        private readonly IMedicineService _service;

        public MedicineController(IMedicineService service)
        {

            _service = service;
        }
        [HttpGet]
        public ActionResult<List<MedicineStock>> GetAllMedicines()
        {
            var medicines = _service.GetAllMedicines();
            if (medicines.Count() == 0)
                return BadRequest("No Medicines");
            else
                return Ok(medicines.ToList<MedicineStock>());
        }
    }
}
