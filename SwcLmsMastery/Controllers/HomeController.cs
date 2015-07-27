using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SwcLmsMastery.Models;
using SwcLmsMastery.Models.DBModels;
using SwcLmsMastery.Repositories;

namespace SwcLmsMastery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Grades = TheOneRepo.GetGradeLevels;

            return View();
        }

        [AllowAnonymous]
        [Authorize (Roles = "Administrator, Teacher, Student, Parent")]
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your dashboard page.";

            return View();
        }

        [Authorize (Roles = "Teacher, Administrator")]
        public ActionResult Gradebook()
        {
            ViewBag.Message = "Your Gradebook page";
            ViewBag.HeaderSpec = "Code to pull course name - ";

            return View();
        }

        [Authorize(Roles = "Teacher, Administrator")]
        public ActionResult Class()
        {
            ViewBag.Message = "My Classes Page";
            ViewBag.HeaderSpec = "Code to pull class name - ";

            return View();
        }


        [Authorize(Roles = "Teacher, Administrator")]
        public ActionResult AddCourse()
        {
            ViewBag.Message = "AddCourse";
            ViewBag.HeaderSpec = "Code to pull course name - ";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UserSearch()
        {
            ViewBag.Message = "User Search";
            ViewBag.HeaderSpec = "Code to pull user info - ";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult UnassignedUsers()
        {
            ViewBag.Message = "Unassigned Users";
            ViewBag.HeaderSpec = "Code to pull user info - ";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCourse(Course course)
        {
            try
            {
                // grab course from DB
                using (var context = new SWC_LMSEntities())
                {
       
                    var dbCourse = context.Courses.FirstOrDefault(x => x.CourseId == course.CourseId);
                    // update course with incoming view model

                    dbCourse.CourseId = course.CourseId;
                    dbCourse.CourseName = course.CourseName;
                    dbCourse.CourseDescription = course.CourseDescription;

   
                    context.SaveChanges();

                    ViewBag.Message = "Save successful";
                }

            }
            catch (Exception e)
            {
                ViewBag.Message = "Error saving user.";
                // throw;
            }
            return View("UserDetails", course);
        }

    }
}