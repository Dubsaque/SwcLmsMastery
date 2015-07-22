using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SwcLmsMastery.Models;
using SwcLmsMastery.Models.DBModels;

namespace SwcLmsMastery.Repositories
{
    public class CourseDbRepo
    {
        public static List<Course> GetCourseList(Course course)
        {
            List<Course> courses = new List<Course>();
            foreach (var co in courses)
            {
                courses.Add(co);
            }
            return courses.ToList();
        }
    }
}