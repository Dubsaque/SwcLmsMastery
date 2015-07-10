USE SWC_LMS
GO

CREATE PROCEDURE LmsUserSelectUnassigned AS

	SELECT Email FROM AspNetUsers WHERE SuggestedRole IS NULL

GO

CREATE PROCEDURE GetGUID @Email varchar(50) AS

SELECT Id
FROM AspNetUsers
WHERE Email = @Email

GO
