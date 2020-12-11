using Dapper;
using PBLSecurity.Models;
using PBLSecurity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_API.Common;

namespace PBLSecurity
{
    public class D3ModelManager : ID3ModelManager
    {
        private string sql;
        private IDbConnection db;

        public D3ModelManager()
        {
            db = new SqlConnection(Tools.ConnectionString);
        }
        public string Get3DmodelBytes() {

            byte[] byteStr = System.IO.File.ReadAllBytes(@"3DModel\office_1");

            string text = BitConverter.ToString(byteStr);

            return text;
        }

        public List<RoomStatusModel> GetRoomStatus(int userID)
        {
            sql = @"SELECT DISTINCT rm.roomName AS RoomName
	                  ,rms.[name] AS 'RoomStatus'
                FROM Room  AS rm
                INNER JOIN Room_Status AS rms ON rm.roomStatusID = rms.roomStatusID
                INNER JOIN Meeting AS mt ON mt.roomID = rm.roomID
                INNER JOIN Meeting_Status AS mts ON mt.meetingStatusID = mts.meetingStatusID
                INNER JOIN Attendees AS att ON att.meetingID = mt.meetingID
                WHERE mts.[name] = 'Created'
                    AND(mt.creatorID = @userID OR att.userID = @userID)
                    AND GETDATE() BETWEEN mt.startTime AND mt.endTime";

            
            return this.db.Query<RoomStatusModel>(sql, new { userID }).ToList();
            //return this.db.Query<TestModel>(sql).ToList();
        }
    }
}
