using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockProject.Models
{
    public interface IMedicineRepository
    {
        public IEnumerable<MedicineStock> GetMedicineList();
    }
}
