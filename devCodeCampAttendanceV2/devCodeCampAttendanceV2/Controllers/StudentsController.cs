using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using devCodeCampAttendanceV2.Models;
using Microsoft.AspNet.Identity;

namespace devCodeCampAttendanceV2.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        
        // GET: Students & Classes
        public ActionResult Current()
        {
            var classStudents = db.ClassStudents.Where(c => c.Class.EndDate > DateTime.Now);
            return View(classStudents);
        }
        public ActionResult StudentHome()
        {
            string userID = User.Identity.GetUserId();  //get current userID
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();    //get user 
            var student = db.Students.Where(s => s.UserID == user.Id).FirstOrDefault(); //get the corresponding student
            DateTime today = DateTime.Now.Date;
            var signedIn = db.SignIns.Where(s => s.Date > today && s.StudentID ==student.ID); //pull signin entries where the student matches and the date is today
            if(student == null)
            {
                return View("Index", "Home");
            }
            else if (signedIn.Count() == 0) //if there are none
            {
                ViewBag.Message = "NOT Signed In.";
            }
            else //if there is one
            {
                ViewBag.Message = "Signed In!";
            }

            return View();
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,SlackID")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.UserID = User.Identity.GetUserId();
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,SlackID")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
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

