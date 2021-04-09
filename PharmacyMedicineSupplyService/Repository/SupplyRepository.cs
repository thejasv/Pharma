using PharmacyMedicineSupplyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Repository
{
    public class SupplyRepository:ISupplyRepository
    {
        private readonly List<string> pharmaciesnames = new List<string> { "MedPlus", "Applo Phrama", "NetMeds", "PharamEasy" };
        private readonly List<PharamacyDTO> pharamacies = new List<PharamacyDTO>();
        public List<PharamacyDTO> GetPharmacies()
        {
            foreach(string phramaname in pharmaciesnames)
            {
                pharamacies.Add(new PharamacyDTO { PharmacyName = phramaname });
            }
            return pharamacies;
        }

       
    }
}
