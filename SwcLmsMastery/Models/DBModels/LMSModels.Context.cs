﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwcLmsMastery.Models.DBModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SWC_LMSEntities : DbContext
    {
        public SWC_LMSEntities()
            : base("name=SWC_LMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<GradeLevel> GradeLevels { get; set; }
        public virtual DbSet<LmsUser> LmsUsers { get; set; }
        public virtual DbSet<Roster> Rosters { get; set; }
        public virtual DbSet<RosterAssignment> RosterAssignments { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
    
        public virtual int LmsUserInsert(string id, string firstName, string lastName, string email, Nullable<byte> gradeLevelId, string suggestedRole, ObjectParameter userId)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var gradeLevelIdParameter = gradeLevelId.HasValue ?
                new ObjectParameter("GradeLevelId", gradeLevelId) :
                new ObjectParameter("GradeLevelId", typeof(byte));
    
            var suggestedRoleParameter = suggestedRole != null ?
                new ObjectParameter("SuggestedRole", suggestedRole) :
                new ObjectParameter("SuggestedRole", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LmsUserInsert", idParameter, firstNameParameter, lastNameParameter, emailParameter, gradeLevelIdParameter, suggestedRoleParameter, userId);
        }
    
        public virtual ObjectResult<GradeLevelSelectAll_Result> GradeLevelSelectAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GradeLevelSelectAll_Result>("GradeLevelSelectAll");
        }
    
        public virtual ObjectResult<LmsUserSelectByAspNetId_Result> LmsUserSelectByAspNetId(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LmsUserSelectByAspNetId_Result>("LmsUserSelectByAspNetId", idParameter);
        }
    
        public virtual ObjectResult<LmsUserSelectByUserId_Result> LmsUserSelectByUserId(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LmsUserSelectByUserId_Result>("LmsUserSelectByUserId", userIdParameter);
        }
    
        public virtual ObjectResult<string> LmsUserSelectUnassigned()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("LmsUserSelectUnassigned");
        }
    
        public virtual ObjectResult<string> GetGUID(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetGUID", emailParameter);
        }
    
        public virtual ObjectResult<GetUserDetails_Result> GetUserDetails(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserDetails_Result>("GetUserDetails", emailParameter);
        }
    
        public virtual int SetUserDetails(string email, Nullable<byte> roleId, ObjectParameter userId)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetUserDetails", emailParameter, roleIdParameter, userId);
        }
    
        public virtual ObjectResult<GetParentDetails_Result> GetParentDetails(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetParentDetails_Result>("GetParentDetails", emailParameter);
        }
    
        public virtual ObjectResult<GetStudentDetails_Result> GetStudentDetails(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentDetails_Result>("GetStudentDetails", emailParameter);
        }
    
        public virtual ObjectResult<GetTeacherDetails_Result> GetTeacherDetails(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTeacherDetails_Result>("GetTeacherDetails", emailParameter);
        }
    
        public virtual int InsertToAspNetUserRoles(string userId, string roleId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            var roleIdParameter = roleId != null ?
                new ObjectParameter("RoleId", roleId) :
                new ObjectParameter("RoleId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertToAspNetUserRoles", userIdParameter, roleIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UnAssignedCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UnAssignedCount");
        }
    
        public virtual int AddCourse(ObjectParameter courseId, string courseName, string courseDescription, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<byte> gradeLevelId, Nullable<bool> isArchived)
        {
            var courseNameParameter = courseName != null ?
                new ObjectParameter("CourseName", courseName) :
                new ObjectParameter("CourseName", typeof(string));
    
            var courseDescriptionParameter = courseDescription != null ?
                new ObjectParameter("CourseDescription", courseDescription) :
                new ObjectParameter("CourseDescription", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var gradeLevelIdParameter = gradeLevelId.HasValue ?
                new ObjectParameter("GradeLevelId", gradeLevelId) :
                new ObjectParameter("GradeLevelId", typeof(byte));
    
            var isArchivedParameter = isArchived.HasValue ?
                new ObjectParameter("IsArchived", isArchived) :
                new ObjectParameter("IsArchived", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddCourse", courseId, courseNameParameter, courseDescriptionParameter, startDateParameter, endDateParameter, gradeLevelIdParameter, isArchivedParameter);
        }
    
        public virtual int InsertUserToAdminRole(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUserToAdminRole", emailParameter);
        }
    
        public virtual int InsertUserToParentRole(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUserToParentRole", emailParameter);
        }
    
        public virtual int InsertUserToStudentRole(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUserToStudentRole", emailParameter);
        }
    
        public virtual int InsertUserToTeacherRole(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertUserToTeacherRole", emailParameter);
        }
    }
}
