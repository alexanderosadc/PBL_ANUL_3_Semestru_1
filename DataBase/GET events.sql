USE PBLSecurity
GO

DECLARE @testUserId int = 1; 

SELECT DISTINCT mt.meetingTitle      
	  ,mt.startTime
      ,mt.endTime
	  ,rm.roomName
	FROM Room AS rm
	INNER JOIN Meeting AS mt ON mt.roomID = rm.roomID
	LEFT JOIN Attendees AS at ON mt.meetingID = at.meetingID
		WHERE mt.creatorID = @testUserId 
			OR at.userID = @testUserId
