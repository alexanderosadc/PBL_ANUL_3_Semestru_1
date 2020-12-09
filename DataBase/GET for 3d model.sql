
SELECT rm.roomName
	  ,rs.name
FROM Room AS rm
INNER JOIN Room_Status AS rs ON rs.roomStatusID = rm.roomStatusID