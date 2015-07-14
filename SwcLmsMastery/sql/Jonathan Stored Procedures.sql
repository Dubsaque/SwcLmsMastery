USE SWC_LMS
GO

ALTER TABLE LmsUser
ADD IsApproved bit
GO


CREATE PROCEDURE LmsUserSelectUnassigned AS

	SELECT Email FROM AspNetUsers WHERE SuggestedRole IS NULL

GO

CREATE PROCEDURE GetGUID @Email varchar(50) AS

SELECT Id
FROM AspNetUsers
WHERE Email = @Email

GO

CREATE PROCEDURE GetUserDetails @Email varchar(50) AS
	SELECT * FROM LmsUser
	LEFT JOIN AspNetUsers 
	ON LmsUser.Id = AspNetUsers.Id
	LEFT JOIN AspNetUserRoles
	ON AspNetUsers.Id = AspNetUserRoles.UserId
	WHERE LmsUser.Email = @Email
GO

CREATE PROCEDURE GetParentDetails @Email varchar(50) AS
	SELECT LmsUser.Email, LmsUser.FirstName, LmsUser.LastName FROM LmsUser
	LEFT JOIN AspNetUsers 
	ON LmsUser.Id = AspNetUsers.Id
	LEFT JOIN AspNetUserRoles
	ON AspNetUsers.Id = AspNetUserRoles.UserId
	WHERE AspNetUserRoles.RoleId = '4'
GO

CREATE PROCEDURE GetStudentDetails @Email varchar(50) AS
	SELECT LmsUser.Email, LmsUser.FirstName, LmsUser.LastName FROM LmsUser
	LEFT JOIN AspNetUsers 
	ON LmsUser.Id = AspNetUsers.Id
	LEFT JOIN AspNetUserRoles
	ON AspNetUsers.Id = AspNetUserRoles.UserId
	WHERE AspNetUserRoles.RoleId = '3'
GO

CREATE PROCEDURE GetTeacherDetails @Email varchar(50) AS
	SELECT LmsUser.Email, LmsUser.FirstName, LmsUser.LastName FROM LmsUser
	LEFT JOIN AspNetUsers 
	ON LmsUser.Id = AspNetUsers.Id
	LEFT JOIN AspNetUserRoles
	ON AspNetUsers.Id = AspNetUserRoles.UserId
	WHERE AspNetUserRoles.RoleId = '2'
GO

CREATE PROCEDURE SetUserDetails (
	@Email varchar(50),
	@RoleId tinyint,
	@UserId int output
	)
	AS
	INSERT INTO AspNetUserRoles(RoleId, UserId)
	VALUES (@RoleId, @UserId)
	SET @UserId = SCOPE_IDENTITY();

GO

