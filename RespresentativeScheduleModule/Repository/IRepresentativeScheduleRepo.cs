using RespresentativeScheduleModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.Repository
{
    public interface IRepresentativeScheduleRepo
    {
        public List<DoctorDTO> GetDoctorsDetails();
        public List<RepresentativeDeatilDTO> GetRepresentativeDeatils();
    }
}
