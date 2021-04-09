using MedicineStockProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockProject.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _repository;

        public MedicineService(IMedicineRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MedicineStock> GetAllMedicines()
        {
            var medicinelist= _repository.GetMedicineList();
            return medicinelist.ToList();
        }

        

    }
}
