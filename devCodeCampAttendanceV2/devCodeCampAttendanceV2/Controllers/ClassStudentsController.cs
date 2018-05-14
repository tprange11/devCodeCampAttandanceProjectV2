using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using devCodeCampAttendanceV2.Models;

namespace devCodeCampAttendanceV2.Controllers
{
    public class ClassStudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClassStudents
        public ActionResult Index()
        {
            var classStudents = db.ClassStudents.Include(c => c.Class).Include(c => c.Student);
            return View(classStudents.ToList());
        }

        // GET: ClassStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent classStudent = db.ClassStudents.Find(id);
            if (classStudent == null)
            {
                return HttpNotFound();
            }
            return View(classStudent);
        }

        // GET: ClassStudents/Create
        public ActionResult Create(int studentID)
        {

            ViewBag.ClassID = new SelectList(db.Classes.Where(c => c.EndDate > DateTime.Now), "ID", "Name");
            var student =db.Students.Where(s => s.ID == studentID).FirstOrDefault();
            var studentName = student.FirstName + " " + student.LastName;
            ViewBag.Student = studentName;
            return View();
        }

        // POST: ClassStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,StudentID")] ClassStudent classStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassStudents.Add(classStudent);
                db.SaveChanges();
                return RedirectToAction("Current", "Students");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", classStudent.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName", classStudent.StudentID);
            return View(classStudent);
        }

        // GET: ClassStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent classStudent = db.ClassStudents.Find(id);
            if (classStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", classStudent.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName", classStudent.StudentID);
            return View(classStudent);
        }

        // POST: ClassStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,StudentID")] ClassStudent classStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", classStudent.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName", classStudent.StudentID);
            return View(classStudent);
        }

        // GET: ClassStudents/Delete/5
        public ActionResult Delete(int? studentID)
        {
            if (studentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent student = db.ClassStudents.Where(cs => cs.StudentID == studentID).FirstOrDefault();
            if (student == null)
            {
                return View("NoJunction");
            }
            return View(student);            
        }

        // POST: ClassStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "ClassID,StudentID")] ClassStudent student)
       
        {
            student.ClassID = Convert.ToInt32(Request["ClassID"]);
            if (ModelState.IsValid)
            {
                db.ClassStudents.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Current", "Students");   
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult NoJunction()
        {
            return View();
        }
    }
}
