using PharmacyMedicineSupplyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.ServiceProvider
{
    public interface IMedicineStockProviderService
    {
        public Task<int> GetStock(string medicinename);
        
        
    }
}
