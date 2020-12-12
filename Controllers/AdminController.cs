using Microsoft.AspNetCore.Mvc;
using PBLSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Test_API.Common;
using Test_API.Data;
using Test_API.Models;

namespace Test_API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Microsoft.AspNetCore.Mvc.Route("api/admin")]
    [ApiController]

    public class AdminController : Controller
    {
        private readonly IMockUserManagement _userService;
        private string userID;

        public AdminController(IMockUserManagement demoService)
        {
            _userService = demoService;
            userID = Tools.UserId();
        }


        [Microsoft.AspNetCore.Mvc.HttpGet("meetings")]
        public IActionResult GetAllMeetings()
        {
            var meetings = _userService.GetAllMeetingsInfo(userID);

            if (meetings == null || meetings.Count() == 0)
            {
                return StatusCode(404);
            }

            return StatusCode(200, meetings);

        }

        [Microsoft.AspNetCore.Mvc.HttpPost("insertMeeting")]
        public IActionResult InsertMeeting([Microsoft.AspNetCore.Mvc.FromBody] InputMeetingModel data)
        {
            var meeting = _userService.InsertMeeting(userID, data.meetingTitle, data.startTime, data.endTime, data.roomName, data.emails);

            if (meeting == false)
            {
                return StatusCode(404);
            }

            return StatusCode(200);

        }

    }
}
