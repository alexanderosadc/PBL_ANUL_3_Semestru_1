using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Common;
using Test_API.Models;

namespace Test_API.Data
{
    public class MockTestData : ITestInterface
    {
        private string sql;
        private IDbConnection db;

        public MockTestData()
        {
            db = new SqlConnection(Tools.ConnectionString);
        }
        public List<TestModel> GetAllTestModels()
        {
            sql = "select * from testTable";
            //using (SqlConnection con = new SqlConnection(_conString))
            //{
            //    if (con.State == ConnectionState.Closed) con.Open();

                return this.db.Query<TestModel>(sql).ToList();
            //}

        }

        public TestModel GetByNumber(int number)
        {
            throw new NotImplementedException();
        }
    }
}
