using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_API.Common;
using Test_API.Models;

namespace Test_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private string _conString;
        private IDbConnection db;
        public WeatherForecastController()
        {
            _conString = Tools.ConnectionString;
            db = new SqlConnection(Tools.ConnectionString);

        }

        [HttpPost]

        public void Post([FromBody]TestModel test)
        {


            string sql = @"INSERT testTable([Name],[Number],[randomData]) 
                           values (@CustomerFirstName, @CustomerLastName, @IsActive)";

            using (SqlConnection con = new SqlConnection(_conString))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                con.Execute(sql, new { CustomerFirstName = test.Name, CustomerLastName = test.Number, IsActive = test.randomData });
            }

        }
    }
}
