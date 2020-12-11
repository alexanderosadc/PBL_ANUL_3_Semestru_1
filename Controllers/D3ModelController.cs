using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PBLSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using PBLSecurity.Services;

namespace PBLSecurity.Controllers
{

    //[ApiController]
    [Route("api/3Dmodel")]

    public class D3ModelController : Controller
    {
        ID3ModelManager d3Model;
        IEnumerable<RoomStatusModel> roomStatus;

        public D3ModelController()
        {
            d3Model = new D3ModelManager();
        }

        [HttpGet("getModel")]
        public String Get()
        {
            return d3Model.Get3DmodelBytes();
        }

        [HttpGet("getRoomStatus")]
        public IActionResult GetRoomStatus()
        {
            roomStatus = d3Model.GetRoomStatus(6);
            if (roomStatus == null || roomStatus.Count() == 0)
            {
                return StatusCode(404);
            }

            return StatusCode(200, roomStatus);
        }
    }
}
