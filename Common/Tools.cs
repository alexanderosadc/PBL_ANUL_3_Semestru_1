using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Test_API.Common
{
    public static class Tools
    {
        public static string ConnectionString { get; set; }

        public static readonly string CorsPolicyName = "PermissiveCorsPolicy";

        public static string UserId()
        {
            using (StreamReader sr = File.OpenText(@"Common\UserID.txt"))
            {
                string userID = sr.ReadLine().Replace(" ", "").Replace("\n", "");
                return userID;

            }
            //string defaultID = "3";
            //return defaultID;
        }

        public static bool isAdmin()
        {
            IDbConnection db = new SqlConnection(Tools.ConnectionString);
            int userID = int.Parse(Tools.UserId());

            string sql = @"SELECT [isAdmin]
                              FROM [User]
                              WHERE userID = @userID";

            var _isAdmin = db.Query<string>(sql, new { userID }).FirstOrDefault();

            if (_isAdmin == "False" || _isAdmin == null)
                return false;

            return true;
        }

    }
}
