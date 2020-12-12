using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLSecurity.Models
{
    public class InsertMeetingDataTestModel
    {
        public string meetingTitle { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int iUserID { get; set; }
        public int meetingStatusID { get; set; }
        public int roomID { get; set; }
    }
}
