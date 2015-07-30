using System;
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
    public class RostersController : Controller
    {
        private SWC_LMSEntities db = new SWC_LMSEntities();

        // GET: Rosters
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Index()
        {
            var rosters = db.Rosters.Include(r => r.Course).Include(r => r.LmsUser);
            return View(await rosters.ToListAsync());
        }

        // GET: Rosters/Details/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roster roster = await db.Rosters.FindAsync(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        // GET: Rosters/Create
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Create(int id)
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", id);
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id", "FirstName");
            return View();
        }

        // POST: Rosters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Create([Bind(Include = "RosterId,CourseId,UserId,CurrentGrade,IsDeleted")] Roster roster)
        {
            if (ModelState.IsValid)
            {
                db.Rosters.Add(roster);
                await db.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", roster.CourseId);
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id", roster.UserId);
            return View(roster);
        }

        // GET: Rosters/Edit/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roster roster = await db.Rosters.FindAsync(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", roster.CourseId);
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id", roster.UserId);
            return View(roster);
        }

        // POST: Rosters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Edit([Bind(Include = "RosterId,CourseId,UserId,CurrentGrade,IsDeleted")] Roster roster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", roster.CourseId);
            ViewBag.UserId = new SelectList(db.LmsUsers, "UserId", "Id", roster.UserId);
            return View(roster);
        }

        // GET: Rosters/Delete/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roster roster = await db.Rosters.FindAsync(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        // POST: Rosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Roster roster = await db.Rosters.FindAsync(id);
            db.Rosters.Remove(roster);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
