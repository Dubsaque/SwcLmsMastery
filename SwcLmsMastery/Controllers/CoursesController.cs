﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SwcLmsMastery.Models.DBModels;

namespace SwcLmsMastery.Controllers
{
    [Authorize(Roles = "Administrator, Teacher")]
    public class CoursesController : Controller
    {

        private SWC_LMSEntities db = new SWC_LMSEntities();

        // GET: Courses
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Index()
        {
            var courses = db.Courses.Include(c => c.Subject).Include(c => c.LmsUser);
            return View(await courses.ToListAsync());
        }

        // GET: Courses/Details/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Create([Bind(Include = "CourseId,UserId,SubjectId,CourseName,CourseDescription,GradeLevel,IsArchived,StartDate,EndDate")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                await db.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", course.SubjectId);
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id", course.UserId);
            return View(course);
        }

        // GET: Courses/Edit/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", course.SubjectId);
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id", course.UserId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Edit([Bind(Include = "CourseId,UserId,SubjectId,CourseName,CourseDescription,GradeLevel,IsArchived,StartDate,EndDate")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", course.SubjectId);
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id", course.UserId);
            return View(course);
        }

        // GET: Courses/Delete/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Course course = await db.Courses.FindAsync(id);
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
