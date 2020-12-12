using PBLSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Models;

namespace Test_API.Data
{
    public interface IMockUserManagement
    {
        List<MeetingModel> GetAllMeetingsInfo(string userID);
        bool InsertMeeting(string userID, string meetingTitle, string startTime, string endTime, string roomName, List<string> emails);
    }
}
