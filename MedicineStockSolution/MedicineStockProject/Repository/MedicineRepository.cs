using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineStockProject.Models
{
    public class MedicineRepository:IMedicineRepository
    {
        List<MedicineStock> medicines;
        public MedicineRepository()
        {
            medicines = new List<MedicineStock>();
            medicines.Add(new MedicineStock
            {

                MedicineName = "Orthoherb",
                ChemicalComposition = "C1,C2",
                TargetAilment ="Orthopaedics",
                DateOfExpiry = Convert.ToDateTime("12/12/2021"),
                NumberOfTabletsInStock=50
            });

            medicines.Add(new MedicineStock
            {

                MedicineName = "Cholecalciferol",
                ChemicalComposition =  "C1,C2",
                TargetAilment = "Orthopaedics",
                DateOfExpiry = Convert.ToDateTime("09/12/2022"),
                NumberOfTabletsInStock = 500
            });

            medicines.Add(new MedicineStock
            {

                MedicineName = "Gaviscon",
                ChemicalComposition =  "C1,C2",
                TargetAilment = "General",
                DateOfExpiry = Convert.ToDateTime("01/12/2022"),
                NumberOfTabletsInStock = 280
            });

            medicines.Add(new MedicineStock
            {

                MedicineName = "Dolo-650",
                ChemicalComposition = "C1,C2",
                TargetAilment = "General",
                DateOfExpiry = Convert.ToDateTime("06/27/2022"),
                NumberOfTabletsInStock = 5000
            });

            medicines.Add(new MedicineStock
            {

                MedicineName = "Cyclopam",
                ChemicalComposition =  "C1,C2",
                TargetAilment = "Gynaecology",
                DateOfExpiry = Convert.ToDateTime("01/06/2022"),
                NumberOfTabletsInStock = 120
            });

            medicines.Add(new MedicineStock
            {

                MedicineName = "Hilact",
                ChemicalComposition ="C1,C2",
                TargetAilment = "Gynaecology",
                DateOfExpiry = Convert.ToDateTime("06/27/2022"),
                NumberOfTabletsInStock = 200
            });

        }
        public IEnumerable<MedicineStock> GetMedicineList()
        {
            return this.medicines.ToList();
        }
    }
}
