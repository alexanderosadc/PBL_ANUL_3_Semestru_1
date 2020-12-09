USE PBLSecurity;
GO

-------- Generate Users
--INSERT INTO [dbo].[User] (name, isAdmin, company)
--VALUES 
--	('William', 0, 'NoName SRL'),
--	('Benjamin', 1, 'NoName SRL'),
--	('Ethan', 1, 'NoName SRL'),
--	('Noah', 0, 'NoName SRL'),
--	('James', 0, 'NoName SRL')

-------- Generate Room statuses
  
--INSERT INTO [Room_Status] (name)
--VALUES 
--	('Empty')
--	('Created'),
--	('Deleted')

-------- Generate Rooms

--INSERT INTO Room (roomName, roomStatusID)
--VALUES 
--	('Death Star', 5),
--	('Hall of Justice', 5),
--	('Spider Skull Island', 5)

-------- Generate Meeting_Status

--INSERT INTO Meeting_Status (name)
--VALUES 
--	('Finished'),
--	('Created'),
--	('Deleted')

-------- Generate Authentication

--INSERT INTO Authentication (authProvider, email, token, userID)
--VALUES 
--	('si ii asta?', 'alex@utm.md', 'dasfdfkj', 1),
--	('si ii asta?', 'ethan@utm.md', 'sdasd1321', 4)

-------- Generate Meeting

--INSERT INTO Meeting (meetingTitle, startTime, endTime, creatorID, meetingStatusID, roomID)
--VALUES 
----	('Demo meet', '2020-12-09 13:23:44', '2020-12-12 13:23:44', 3, 2, 1)
--	('test demo meeting', '2020-12-05 14:00:00', '2020-12-15 10:00:00', 4, 2, 3)
-------- Generate Attendees


--INSERT INTO Attendees (meetingID, userID)
--VALUES 
--	(1, 1),
--	(1, 2),
--	(1, 6)
