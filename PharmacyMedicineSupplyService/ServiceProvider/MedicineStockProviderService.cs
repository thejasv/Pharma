using Newtonsoft.Json;
using PharmacyMedicineSupplyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.ServiceProvider
{
    public class MedicineStockProviderService : IMedicineStockProviderService
    {
        
        public async Task<int> GetStock(string medicinename)
        {
            try
            {
                HttpClient client = new HttpClient();
                var MyResponse = await client.GetAsync("http://localhost:7192/api/medicine");
                if (MyResponse.IsSuccessStatusCode)
                {
                    string stringdata = await MyResponse.Content.ReadAsStringAsync();
                    var medicines = JsonConvert.DeserializeObject<List<MedicineStock>>(stringdata);
                    var med = medicines.Find(x => x.MedicineName .Equals(medicinename));
                    return med.NumberOfTabletsInStock;
                }
                else
                {
                    return -1;
                }
            }
            catch(Exception)
            {
                throw;
            }

        }
    }
}
