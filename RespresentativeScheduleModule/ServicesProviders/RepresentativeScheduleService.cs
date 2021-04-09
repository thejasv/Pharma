using RespresentativeScheduleModule.Models;
using RespresentativeScheduleModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.ServicesProviders
{
    public class RepresentativeScheduleService : IRepresentativeScheduleService
    {
        private List<DoctorDTO> _doctorslist=new List<DoctorDTO>();
        private List<RepresentativeDeatilDTO> _representativeslist=new List<RepresentativeDeatilDTO>();
        private readonly List<DateTime> _dates = new List<DateTime>();
        private readonly IRepresentativeScheduleRepo _reprenatativescheduleRepo;
        private readonly IMedicineStockService _medicineStockService;
        private  List<MedicineStock> _medicinelist = new List<MedicineStock>();
        private readonly List<RepresentativeSchedule> _representativeschedule = new List<RepresentativeSchedule>();

        public RepresentativeScheduleService(IRepresentativeScheduleRepo scheduleRepo,IMedicineStockService medicineStockService)
        {
            _reprenatativescheduleRepo = scheduleRepo;
            _medicineStockService = medicineStockService;
        }
        public List<DoctorDTO> GetDoctorsDetails()
        {
            try
            {
                return _reprenatativescheduleRepo.GetDoctorsDetails();
            }
            catch
            {
                throw;
            }
        }

        public List<RepresentativeDeatilDTO> GetRepresentativeDetails()
        {
            try
            {
                return _reprenatativescheduleRepo.GetRepresentativeDeatils();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<RepresentativeSchedule>> GetSchedule(DateTime startdate)
        {
            try
            {
                if (_dates.Count > 0)
                {
                    _dates.Clear();
                }
                DateTime start = startdate;
                DateTime end = start.AddDays(6);
                int workDays = 0;
                while (start != end)
                {
                    if (start.DayOfWeek != DayOfWeek.Sunday)
                    {
                        _dates.Add(start);
                        workDays++;
                    }
                    if (workDays == 5)
                    {
                        break;
                    }
                    start = start.AddDays(1);
                }
                _representativeslist = GetRepresentativeDetails();
                _doctorslist = GetDoctorsDetails();
                _medicinelist = await _medicineStockService.GetMedicineStock();
                if(_representativeslist.Count==0||_doctorslist.Count==0||_medicinelist.Count==0|| _representativeslist == null || _doctorslist == null || _medicinelist == null)
                {
                    return null;
                }
                for (var i = 0; i < _dates.Count; i++)
                {
                    var rep = new RepresentativeSchedule
                    {
                        RepresentativeName = _representativeslist[i % _representativeslist.Count].RespresentativeName,
                        DoctorName = _doctorslist[i].DoctorName,
                        TreatingAilment = _doctorslist[i].TreatingAilment,
                        MeetingSlot = "1Pm-2Pm",
                        DateOfMeeting = _dates[i].ToShortDateString(),
                        DoctorContactNumber=_doctorslist[i].ContactNumber
                    };
                    List<string> medicine = _medicinelist.Where(s => s.TargetAilment == rep.TreatingAilment).Select(s => s.MedicineName).ToList();
                    rep.Medicine = String.Join(",", medicine);
                    _representativeschedule.Add(rep);
                }
                return _representativeschedule;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
