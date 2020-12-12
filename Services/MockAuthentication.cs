using Dapper;
using PBLSecurity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Common;

namespace PBLSecurity.Services
{
    public class MockAuthentication : IMockAuthentication
    {

        private string sql;
        private IDbConnection db;
        private string userName;
        private string userCompany;
        private string _userID;
        private string authProvider;
        private string path;
    

        public MockAuthentication()
        {
            db = new SqlConnection(Tools.ConnectionString);
            authProvider = "GMAIL";
            path = @"Common\UserID.txt";
            //(@"3DModel\office_1")

        }

        public bool CheckAuth(string email, string token)
        {
            var userEmail = VerifyEmail(email);
            if (userEmail == null) 
            {
                bool userCreationChecker = CreateUser(email);
                if (userCreationChecker == false)
                    return false;

                _userID = ExtractUserID();

                InsertIDToFile(_userID);

                CreateAuth(email, token, _userID);
                return true;
            }

            ExtractLoggedUserID(email);
            return true;
        }

        private void ExtractLoggedUserID(string email)
        {
            var userData = email.Split('@');

            userName = userData[0];
            userCompany = userData[1];

            sql = @"SELECT userID
                    FROM [User]
                    WHERE [name] = @userName AND company = @userCompany";

            var userID = this.db.Query<string>(sql, new { userName, userCompany }).FirstOrDefault();

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(userID);
            }
        }

        private void InsertIDToFile(string userID)
        {

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(userID);
            }
        }

        private void CreateAuth(string email, string token, string userID)
        {

            sql = @"INSERT INTO [Authentication] (email, authProvider, token, userID)
                    VALUES
	                    (@email, @authProvider, @token, @userID)";
            
            this.db.Query<string>(sql, new { email, authProvider, token, userID });
        }

        private string ExtractUserID()
        {

            sql = @"SELECT userID
                    FROM [User]
                    WHERE [name] = @userName AND company = @userCompany";             

            return this.db.Query<string>(sql, new { userName, userCompany }).FirstOrDefault();
        }

        private bool CreateUser(string email)
        {
            var userData = email.Split('@');
            if (userData.Length != 2)
                return false;

            userName = userData[0];
            userCompany = userData[1];

            sql = @"INSERT INTO [User] ([name], isAdmin, company)
                    VALUES
	                    (@userName, 0, @userCompany)";

            //var execute = 
                this.db.Query<string>(sql, new { userName, userCompany }).FirstOrDefault();

            //if (execute == null || execute.Length == 0)
            //    return false;

            return true;
        }

        private string VerifyEmail(string email)
        {

            sql = @"SELECT email
                    FROM[Authentication]
                    WHERE email = @email";

            return this.db.Query<string>(sql, new { email }).FirstOrDefault();
        }

    }
}
