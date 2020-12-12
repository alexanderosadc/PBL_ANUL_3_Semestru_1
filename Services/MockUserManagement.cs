using Dapper;
using PBLSecurity.Models;
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
    public class MockUserManagement : IMockUserManagement
    {
        private string sql;
        private IDbConnection db;

        public MockUserManagement()
        {
            db = new SqlConnection(Tools.ConnectionString);
        }
        public List<MeetingModel> GetAllMeetingsInfo(string userID)
        {
            sql = @"SELECT mt.meetingTitle
	                      ,mt.startTime
	                      ,mt.endTime
	                      ,att.userID
	                      ,aut.email
                    FROM Meeting as mt
                    LEFT OUTER JOIN [Attendees] AS att On mt.meetingID = att.meetingID
			                    --AND att.userID IS NOT NULL
                    LEFT OUTER JOIN [User] AS us ON att.userID = us.userID  
                    LEFT OUTER JOIN [Authentication] AS aut ON us.userID = aut.userID
                    WHERE 
	                    att.userID = @userID OR
	                    mt.creatorID = @userID 
	                    AND att.userID IS NOT NULL 
	                    AND aut.email IS NOT NULL";

            return this.db.Query<MeetingModel>(sql, new { userID }).ToList();
        }

        public bool InsertMeeting(string userID, string meetingTitle, string startTime, string endTime, string roomName, List<string> emails)
        {
            ChangeRoomStatus(roomName);

            bool isNameValid = CheckMeetingName(roomName);
            if (isNameValid == false)
                return false;

            bool isMeetingCreated = InsertMeetingData(userID, meetingTitle, startTime, endTime, roomName);
            if (isMeetingCreated == false)
                return false;

            int meetingId = GetMeetingID(meetingTitle);

            foreach (var email in emails)
            {
                InsertAttendees(meetingId, email);
            }

            return true;
        }

        private void InsertAttendees(int meetingId, string email)
        {
            int userID = GetUserIDByEmail(email);

            sql = @" INSERT INTO Attendees ([meetingID], [userID])
                      VALUES 
	                    (@meetingId, @userID)";

            this.db.Query<string>(sql, new { meetingId, userID });
        }

        private int GetUserIDByEmail(string email)
        {

            sql = @"SELECT us.[userID]      
                      FROM [User] as us
                      INNER JOIN [Authentication] as aut ON aut.userID = us.userID
                        WHERE aut.email = @email";

            return int.Parse(this.db.Query<string>(sql, new { email }).FirstOrDefault());
        }

        private int GetMeetingID(string meetingTitle)
        {

            sql = @"SELECT  [meetingID]
                    FROM [Meeting]
                    WHERE meetingTitle = @meetingTitle";

            return int.Parse(this.db.Query<string>(sql, new { meetingTitle }).FirstOrDefault());
        }

        private bool InsertMeetingData(string userID, string meetingTitle, string startTime, string endTime, string roomName)
        {

            int iUserID = int.Parse(userID);
            int meetingStatusID = GetCreatedMeetingStatus();
            int roomID = ExtractRoomID(roomName);

            sql = @"INSERT INTO Meeting (meetingTitle, startTime, endTime, creatorID, meetingStatusID, roomID)
                    VALUES 
	                    (@meetingTitle, CAST(@startTime as DATE), CAST(@endTime as DATE), @iUserID, @meetingStatusID, @roomID)";


            this.db.Query<InsertMeetingDataTestModel>(sql, new { meetingTitle, startTime, endTime, iUserID, meetingStatusID, roomID}).FirstOrDefault();

            //if (meeting == null /*|| meeting.Length == 0*/)
            //    return false;

            return true;
        }

        private int GetCreatedMeetingStatus()
        {
            sql = @"SELECT [meetingStatusID]
                    FROM [Meeting_Status]
                    WHERE [name] = 'Created'";

            return int.Parse(this.db.Query<string>(sql).FirstOrDefault());
        }

        private bool CheckMeetingName(string roomName)
        {

            sql = @"SELECT meetingID
                    FROM Meeting
                    WHERE meetingTitle = @roomName";

            var data = this.db.Query<string>(sql, new { roomName }).FirstOrDefault();

            if (data == null || data.Length == 0)
                return true;

            return false;
        }
        private void ChangeRoomStatus(string roomName)
        {
            var roomStatusID = GetCreatedRoomStatus();

            sql = @"Update Room
                    SET roomStatusID = @roomStatusID
                    WHERE roomName = @roomName";

            this.db.Query<string>(sql, new { roomStatusID, roomName });
        }

        private int ExtractRoomID(string roomName)
        {
            sql = @"SELECT [roomID]
                  FROM Room
                  WHERE roomName = @roomName";

            return int.Parse(this.db.Query<string>(sql, new { roomName }).FirstOrDefault());
        }

        private int GetCreatedRoomStatus()
        {
            sql = @"SELECT roomStatusID
                    FROM Room_Status
                    WHERE [name] = 'Created'";

            return int.Parse(this.db.Query<string>(sql).FirstOrDefault());
        }

    }
}
