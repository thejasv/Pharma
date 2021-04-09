using PharmacyMedicineSupplyService.Models;
using PharmacyMedicineSupplyService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.ServiceProvider
{
    public class PharmacySupplyProviderService : IPharmacySupplyProvider
    {
        private readonly ISupplyRepository _supplyRepo;
        private List<PharamacyDTO> pharmacies;
        private readonly IMedicineStockProviderService _stockProvider;
        
        private List<PharmacyMedicineSupply> pharmacySupply = new List<PharmacyMedicineSupply>();
        public PharmacySupplyProviderService(ISupplyRepository supplyRepository, IMedicineStockProviderService medicineStockProvider)
        {
            _supplyRepo = supplyRepository;
            _stockProvider = medicineStockProvider;
        }
        public async Task<List<PharmacyMedicineSupply>> GetSupply(List<MedicineDemand> medicines)
        {
            pharmacies = _supplyRepo.GetPharmacies();
            foreach (var med in medicines)
            {

                if (med.DemandCount > 0)
                {
                    var stockCount = await _stockProvider.GetStock(med.MedicineName);
                    if (stockCount != -1)
                    {
                        if (stockCount < med.DemandCount)
                            med.DemandCount = stockCount;
                        int indSupply = (med.DemandCount) / pharmacies.Count;
                        foreach (var i in pharmacies)
                        {
                            pharmacySupply.Add(new PharmacyMedicineSupply { MedicineName = med.MedicineName, PharmacyName = i.PharmacyName, SupplyCount = indSupply });
                        }
                        if (med.DemandCount > indSupply * pharmacies.Count)
                        {
                            pharmacySupply[pharmacySupply.Count - 1].SupplyCount += (med.DemandCount - indSupply * pharmacies.Count);
                        }
                    }

                }
            }
            return pharmacySupply;
        }

        
    }
}
