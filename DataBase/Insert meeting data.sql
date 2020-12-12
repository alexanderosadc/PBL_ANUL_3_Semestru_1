USE PBLSecurity;
GO
DECLARE @meetingTitle nvarchar(255) = 'test insert';
DECLARE @startTime nvarchar(255) = '2020-01-01 00:00:00';
DECLARE @endTime nvarchar(255) = '2020-12-01 00:00:00';
DECLARE @creatorID int = 4;
DECLARE @roomID int = 3;
DECLARE @meetingStatusID int = 2;

DECLARE @meetingID int = 5;
DECLARE @userID int = 1;
DECLARE @email nvarchar(255) = 'alex@utm.md'

--SELECT TOP (1000) [meetingID]
--      ,[meetingTitle]
--      ,[startTime]
--      ,[endTime]
--      ,[creatorID]
--      ,[meetingStatusID]
--      ,[roomID]
--  FROM [PBLSecurity].[dbo].[Meeting]


-- insert info about meeting
--INSERT INTO [Meeting] (meetingTitle, startTime, endTime, creatorID, meetingStatusID, roomID)
--VALUES 
--	(@meetingTitle, @startTime, @endTime, @creatorID, @meetingStatusID, @roomID)

--extract meetingID for created meeting
--SELECT meetingID
--FROM Meeting
--WHERE meetingTitle = @meetingTitle

--SELECT email
--FROM [Authentication]
--WHERE email = @email;

-- insert attendees
--INSERT INTO Attendees(meetingID, userID)
--VALUES
	--(@meetingID, @userID)





-------######################################


--- Have room ID
--SELECT [roomID]
--  FROM Room
--  WHERE roomName = 'Death Star'

--SELECT roomStatusID
--FROM Room_Status
--WHERE [name] = 'Created'
-- Change room status 

--Update Room
--SET roomStatusID = 5
--WHERE roomName = 'Death Star'

--check if name is not already used
--SELECT meetingID
--FROM Meeting
--WHERE meetingTitle = 'problem1'
----insert data in meeting

--SELECT TOP (1000) [meetingID]
--      ,[meetingTitle]
--      ,[startTime]
--      ,[endTime]
--      ,[creatorID]
--      ,[meetingStatusID]
--      ,[roomID]
--  FROM [PBLSecurity].[dbo].[Meeting]

--INSERT INTO [Authentication] (email, authProvider, token, userID)
--VALUES
--	(@email, @authProvider, @token, @userID)

--INSERT INTO (meetingTitle, startTime, endTime, creatorID, meetingStatusID, roomID)
--VALUES 
--	(@meetingTitle, @startTime, @endTime, @creatorID, @meetingStatusID, @roomID)
