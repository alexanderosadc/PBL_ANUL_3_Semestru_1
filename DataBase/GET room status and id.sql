
DECLARE @inputID int = 6

SELECT DISTINCT rm.roomName AS RoomName
	  ,rms.[name] AS 'RoomStatus'
FROM Room  AS rm
INNER JOIN Room_Status AS rms ON rm.roomStatusID = rms.roomStatusID
INNER JOIN Meeting AS mt ON mt.roomID = rm.roomID
INNER JOIN Meeting_Status AS mts ON mt.meetingStatusID = mts.meetingStatusID
INNER JOIN Attendees AS att ON att.meetingID = mt.meetingID
WHERE mts.[name] = 'Created' 
	AND (mt.creatorID = @inputID OR att.userID = @inputID) 
	AND GETDATE() BETWEEN mt.startTime AND mt.endTime
