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

CREATE PROCEDURE UnAssignedCount AS
SELECT COUNT(*) FROM LmsUser WHERE IsApproved IS NULL
GO

CREATE PROCEDURE AddCourse (
@CourseId int output,
@CourseName varchar(30),
@CourseDescription varchar(30),
@StartDate DATETIME,
@EndDate DATETIME,
@GradeLevelId tinyint,
@IsArchived bit
) AS

INSERT INTO Course (CourseId, CourseName, CourseDescription, StartDate, EndDate, GradeLevel, IsArchived)
VALUES (@CourseId, @CourseName, @CourseDescription, @StartDate, @EndDate, @GradeLevelId, @IsArchived)

SET @CourseId = SCOPE_IDENTITY();
GO


CREATE PROCEDURE InsertUserToRole @Email varchar(50),  AS

SELECT Id
FROM AspNetUsers
WHERE Email = @Email

GO

ALTER PROCEDURE InsertUserToAdminRole @Email varchar(50) AS
INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT Id, '1' FROM AspNetUsers WHERE email = @Email 
GO

ALTER PROCEDURE InsertUserToTeacherRole @Email varchar(50) AS
INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT Id, '2' FROM AspNetUsers WHERE email = @Email
GO

ALTER PROCEDURE InsertUserToStudentRole @Email varchar(50) AS
INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT Id, '3' FROM AspNetUsers WHERE email = @Email
GO

ALTER PROCEDURE InsertUserToParentRole @Email varchar(50) AS
INSERT INTO AspNetUserRoles (UserId, RoleId)
SELECT Id, '4' FROM AspNetUsers WHERE email = @Email
GO
