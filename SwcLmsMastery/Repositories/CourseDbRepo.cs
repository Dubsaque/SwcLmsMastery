using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SwcLmsMastery.Models;
using SwcLmsMastery.Models.DBModels;

namespace SwcLmsMastery.Repositories
{
    public class CourseDbRepo
    {

        SWC_LMSEntities context = new SWC_LMSEntities();

        public static List<Course> GetCourseList(Course course)
        {
            List<Course> courses = new List<Course>();
            foreach (var co in courses)
            {
                courses.Add(co);
            }
            return courses.ToList();
        }

        public static void AddCourse(CourseViewModel course)
        {
            SWC_LMSEntities context = new SWC_LMSEntities();
            {

            var startDate = DateTime.Parse(course.StartDate);
            var endDate = DateTime.Parse(course.EndDate);
            context.AddCourse(course.CourseId, course.SubjectId, course.CourseName, course.CourseDescription, course.IsArchived, startDate, endDate);
     
     
  context.SaveChanges();
            }
        }

        public static void EditCourse(CourseViewModel course)
        {
            SWC_LMSEntities context = new SWC_LMSEntities();
            {

                Course newCourse = new Course();
                newCourse.CourseName = "Test Info";
                newCourse.CourseDescription = "Test Info Desc";
                newCourse.StartDate = DateTime.Now;
                newCourse.EndDate = DateTime.Now;
                context.Courses.Add(newCourse);
                context.SaveChanges();


            }
        }

      
    }
}