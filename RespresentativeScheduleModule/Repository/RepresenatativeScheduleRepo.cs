using RespresentativeScheduleModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.Repository
{
    public class RepresenatativeScheduleRepo:IRepresentativeScheduleRepo
    {
        private List<Doctor> Doctors;
        private List<RepresentativeDetail> RepresentativeDetails;
        List<DoctorDTO> DocDetails = new List<DoctorDTO>();
        List<RepresentativeDeatilDTO> RepresentDetails = new List<RepresentativeDeatilDTO>();
        public RepresenatativeScheduleRepo()
        {
            Doctors = new List<Doctor>()
            {
                new Doctor{DoctorName="Doctor1",ContactNumber="9876543210",TreatingAilment="Orthopaedics"},
                new Doctor{DoctorName="Doctor2",ContactNumber="9845678210",TreatingAilment="General"},
                new Doctor{DoctorName="Doctor3",ContactNumber="9878943210",TreatingAilment="Gynecology"},
                new Doctor{DoctorName="Doctor4",ContactNumber="9876973210",TreatingAilment="General"},
                new Doctor{DoctorName="Doctor5",ContactNumber="9876544710",TreatingAilment="Gynecology"}
            };
            RepresentativeDetails = new List<RepresentativeDetail>()
            {
                new RepresentativeDetail{RespresentativeName="Representative1"},
                new RepresentativeDetail{RespresentativeName="Representative2"},
                new RepresentativeDetail{RespresentativeName="Representative3"}
            };
        }
       
        public List<DoctorDTO> GetDoctorsDetails()
        {
            foreach(var i in Doctors)
            {
                DocDetails.Add(new DoctorDTO { DoctorName=i.DoctorName,ContactNumber=i.ContactNumber,TreatingAilment=i.TreatingAilment});
            }
            return DocDetails;

        }

        public List<RepresentativeDeatilDTO> GetRepresentativeDeatils()
        {
            foreach(var i in RepresentativeDetails)
            {
                RepresentDetails.Add(new RepresentativeDeatilDTO { RespresentativeName = i.RespresentativeName });
            }
            return RepresentDetails;
        }
    }
}
