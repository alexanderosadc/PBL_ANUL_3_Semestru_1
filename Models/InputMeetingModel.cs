using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBLSecurity.Models
{
    public class InputMeetingModel
    {
        public string meetingTitle { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string roomName { get; set; }
        public List<string> emails { get; set; } 
    }
}
