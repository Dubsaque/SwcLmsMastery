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
    public class AssignmentsController : Controller
    {
        private SWC_LMSEntities db = new SWC_LMSEntities();

        // GET: Assignments
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Index()
        {
            var assignments = db.Assignments.Include(a => a.Course);
            return View(await assignments.ToListAsync());
        }

        // GET: Assignments/Details/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = await db.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: Assignments/Create
        [Authorize(Roles = "Administrator, Teacher")]
        public ActionResult Create(int id)
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", id);
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Create([Bind(Include = "AssignmentId,CourseId,AssignmentName,PossiblePoints,DueDate,AssignmentDescription")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Assignments.Add(assignment);
                await db.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", assignment.CourseId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = await db.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", assignment.CourseId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Edit([Bind(Include = "AssignmentId,CourseId,AssignmentName,PossiblePoints,DueDate,AssignmentDescription")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Dashboard", "Home");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", assignment.CourseId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = await db.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Assignment assignment = await db.Assignments.FindAsync(id);
            db.Assignments.Remove(assignment);
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
