using MedicineStockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockProject.Services
{
    public interface IMedicineService
    {
        public IEnumerable<MedicineStock> GetAllMedicines();
    }
}
