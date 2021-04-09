using RespresentativeScheduleModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.ServicesProviders
{
    public interface IRepresentativeScheduleService
    {
        public Task<List<RepresentativeSchedule>> GetSchedule(DateTime date);
        public List<DoctorDTO> GetDoctorsDetails();
        public List<RepresentativeDeatilDTO> GetRepresentativeDetails();

    }
}
