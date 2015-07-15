using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult MyClasses()
        {
            ViewBag.Message = "My Classes Page";     

            return View();
        }

        [Authorize(Roles = "Teacher, Administrator")]
        public ActionResult AddClass()
        {
            ViewBag.Message = "AddClass";
            ViewBag.HeaderSpec = "Code to pull course name - ";

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
    }
}