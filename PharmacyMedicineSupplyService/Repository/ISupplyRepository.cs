using PharmacyMedicineSupplyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Repository
{
   public interface ISupplyRepository
    {
        public List<PharamacyDTO> GetPharmacies();
    }
}
