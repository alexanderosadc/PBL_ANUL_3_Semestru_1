

DECLARE @email nvarchar(255) = 'notalex@utm.md'
DECLARE @token nvarchar(255) = 'sdasfdsbnwfdsfsd'
--DECLARE @email nvarchar(255) = 'alex@utm.md'
DECLARE @name nvarchar(255) = 'notAlex'
DECLARE @isAdmin int = 0
DECLARE @company nvarchar(255) = 'utm.md'
DECLARE @userID int = 7
DECLARE @auhProvider nvarchar(255) = 'random stuff'


--SELECT email
--FROM [Authentication]
--WHERE email = @email

--INSERT INTO [User] ([name], isAdmin, company)
--VALUES
--	(@name, @isAdmin, @company)

--SELECT userID
--FROM [User]
--WHERE [name] = @name AND company = @company



INSERT INTO [Authentication] (email, authProvider,token, userID)
VALUES
	(@email, @auhProvider, @token, @userID)



