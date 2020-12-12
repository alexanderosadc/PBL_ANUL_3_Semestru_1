using Microsoft.AspNetCore.Mvc;
using PBLSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Common;
using Test_API.Data;
using Test_API.Models;

namespace Test_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IMockUserManagement _userService;
        private string userID;

        public UserController(IMockUserManagement demoService)
        {
            _userService = demoService;
            userID = Tools.UserId();
        }


        [HttpGet("meetings")]
        public IActionResult GetAllMeetings()
        {
            var meetings = _userService.GetAllMeetingsInfo(userID);

            if (meetings == null || meetings.Count() == 0)
            {
                return StatusCode(404);
            }

            return StatusCode(200, meetings);

        }

        [HttpPost("insertMeeting")]
        public IActionResult InsertMeeting([FromBody] InputMeetingModel data)
        {
            var meeting = _userService.InsertMeeting(userID, data.meetingTitle, data.startTime, data.endTime, data.roomName, data.emails);

            if (meeting == false)
            {
                return StatusCode(404);
            }

            return StatusCode(200);

        }


        //[HttpGet("testmeet/{data}")]
        //public IActionResult GetTEST(string data)
        //{
        //    var meetings = _userService.InsertMeeting(data);

        //    return StatusCode(200, meetings);

        //}
    }
}
