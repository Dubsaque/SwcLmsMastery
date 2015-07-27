using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SwcLmsMastery.Models;
using SwcLmsMastery.Models.DBModels;

namespace SwcLmsMastery.Repositories
{
    public class UserDbRepo
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


        public static List<IdentityUserRole> GetRoles(ApplicationUser user)
        {
            List<IdentityUserRole> roles = new List<IdentityUserRole>();
            foreach (var role in user.Roles)
            {
                roles.Add(role);
            }
            return roles;
        }

        public static LmsUser GetUserWithRoles(int id)
        {
            using (var db = new SWC_LMSEntities())
            {
                var dbUser = db.LmsUsers.FirstOrDefault(x => x.UserId == id);
                // dbUser.Roles = 
            }

            return null;
        }

        public static List<AspNetRole> GetAllRoles()
        {
            using (var db = new SWC_LMSEntities())
            {
                var roles = db.AspNetRoles; // from r in db.AspNetRoles select r;  // db.AspNetRoles.ToList();
                return roles.OrderBy(r => r.Name).ToList();
            }
        }

        public List<LmsUser> Search(string firstName, string lastName, string eMail)
        {
            using (var context = new SWC_LMSEntities())
            {
                context.LmsUsers.Where(x => x.FirstName.ToUpper().Contains(firstName.ToUpper()) ||
                                            x.LastName.ToUpper().Contains(lastName.ToUpper()) ||
                                            x.Email.ToUpper().Contains(eMail.ToUpper())).ToList();
            }
        }

    }
}