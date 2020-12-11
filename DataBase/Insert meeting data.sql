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