using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RespresentativeScheduleModule.Models
{
    public class RepresentativeSchedule
    {
        public string RepresentativeName { get; set; }
        public string DoctorName { get; set; }
        public string TreatingAilment { get; set; }
        public string Medicine { get; set; }
        public string MeetingSlot { get; set; }
        public string DateOfMeeting { get; set; } 
        public string DoctorContactNumber { get; set; }

    }
}
