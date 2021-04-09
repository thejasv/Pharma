using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.Models
{
    public class MedicineStock
    {
        public string MedicineName { get; set; }
        public string ChemicalComposition { get; set; }
        public string TargetAilment { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public int NumberOfTabletsInStock { get; set; }
    }
}
