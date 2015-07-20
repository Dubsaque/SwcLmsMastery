using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SwcLmsMastery.Models;
using SwcLmsMastery.Models.DBModels;

namespace SwcLmsMastery.Repositories
{
    public class TheOneRepo
    {
        public static List<LmsUserSelectUnassignedResult> LmsUserSelectUnassigned()
        {
            using (var db = new SWC_LMSEntities())
            {
                var results = db.LmsUserSelectUnassigned().FirstOrDefault();
                return LmsUserSelectUnassigned();
            }
        }

        public static void InsertNewUserToDb(RegisterViewModel reg, string id)
        {
            using (var db = new SWC_LMSEntities())
            {
                var output = new ObjectParameter("UserId", typeof(int));
                db.LmsUserInsert(id, reg.Fname, reg.Lname, reg.Email,
                    reg.GradeLevelId, reg.SuggestedRole, output);

            }
        }

        public static void InsertNewUserToAspNetUserRoles(LmsUserViewModel reg, string id)
        {
            using (var db = new SWC_LMSEntities())
            {
                var output = new ObjectParameter("UserId", typeof(int));
                db.InsertToAspNetUserRoles(reg.UserId.ToString(), reg.Roles.ToString());

            }
        }

        public static string GetId(string email)
        {
            using (var db = new SWC_LMSEntities())
            {
                var results = db.GetGUID(email).FirstOrDefault();
                return results;
            }
        }

        //public static string GetUserDets(string email)
        //{
        //    using (var db = new SWC_LMSEntities())
        //    {
        //        var results = db.GetUserDets(email);
        //        return results;
        //    }
        //}

        public static List<IdentityUserRole> GetRoles(ApplicationUser user)
        { 
            List<IdentityUserRole> roles = new List<IdentityUserRole>();
            foreach (var role in user.Roles)
            {
                roles.Add(role);
            }
            return roles;
        }

        public static List<SelectListItem> GetGradeLevels
        {
            get
            {
                List<SelectListItem> ret = new List<SelectListItem>();

                using (var db = new SWC_LMSEntities())
                {

                    var gradelvl = db.GradeLevelSelectAll().ToList();
                    foreach (var g in gradelvl)
                    {
                        ret.Add(new SelectListItem { Text = g.GradeLevelName, Value = g.GradeLevelId.ToString() } );
                    }

                    return ret;
                }
            }
        }

    }
}