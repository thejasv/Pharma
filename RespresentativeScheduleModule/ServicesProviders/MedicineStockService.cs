using Newtonsoft.Json;
using RespresentativeScheduleModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.ServicesProviders
{
    public class MedicineStockService:IMedicineStockService
    {
        List<MedicineStock> medicinestock = new List<MedicineStock>() { };
        
        public async Task<List<MedicineStock>> GetMedicineStock()
        {
            try
            {
                HttpClient client = new HttpClient();
                
                using (var MyResponse = await client.GetAsync("http://localhost:7192/api/medicine"))
                {

                    if (MyResponse.IsSuccessStatusCode)
                    {
                        string stringData= MyResponse.Content.ReadAsStringAsync().Result;
                        medicinestock = JsonConvert.DeserializeObject<List<MedicineStock>>(stringData);
                       
                    }
                    else if (MyResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        medicinestock = null;
                    }
                    else
                    {
                        throw new Exception("Internal error in api called");
                    }
                }
                return medicinestock;
            }
            catch(Exception)
            {
                throw;
            }
        }

       
    }
}
