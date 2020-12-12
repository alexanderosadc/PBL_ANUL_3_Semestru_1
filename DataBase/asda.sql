/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT TOP (1000) [meetingID]
--      ,[meetingTitle]
--      ,[startTime]
--      ,[endTime]
--      ,[creatorID]
--      ,[meetingStatusID]
--      ,[roomID]
--  FROM [PBLSecurity].[dbo].[Meeting]

SELECT mt.meetingTitle
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
	att.userID = 6 OR
	mt.creatorID = 6 
	AND att.userID IS NOT NULL 
	AND aut.email IS NOT NULL

--SELECT att.userID
--	  ,mt.meetingTitle
--	  ,mt.startTime
--	  ,mt.endTime
--FROM Attendees AS att
--INNER JOIN Meeting AS mt ON mt.meetingID = att.meetingID
--			AND mt.creatorID = 3
--INNER JOIN [User] AS us ON us.userID = att.userID
--INNER JOIN [Authentication] AS aut ON aut.userID = us.userID
--WHERE mt.creatorID = 3