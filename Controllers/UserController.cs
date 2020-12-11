using Microsoft.AspNetCore.Mvc;
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
        private readonly ITestInterface _demoService;

        public UserController(ITestInterface demoService)
        {
            _demoService = demoService;

        }

        //[HttpPost("authenticationSSO")]
        //public IActionResult Post([FromBody]  ourCustomer)
        //{


        //    return StatusCode(200, roomStatus);
        //}

        // GET api/values
        [HttpGet("all")]
        public ActionResult<List<TestModel>> GetAll()
        {
            return _demoService.GetAllTestModels();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
