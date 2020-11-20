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

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _conString = Tools.ConnectionString;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]

        public void Post([FromBody]Test test)
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
