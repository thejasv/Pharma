﻿using RespresentativeScheduleModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.ServicesProviders
{
    public interface IMedicineStockService
    {
        public Task<List<MedicineStock>> GetMedicineStock();
    }
}
