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
    public class SignInsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SignIns

        public ActionResult Today()
        {
            var todaysSignIns = db.SignIns.Where(s => s.Date == DateTime.Today).ToList();
            return View(todaysSignIns);
        }
        public ActionResult Index()
        {

            if (User.IsInRole("Instructor"))
            {
                var signIns = db.SignIns.Include(s => s.Class).Include(s => s.Student);
                return View(signIns.ToList());
            }
            else if(User.IsInRole("Student"))
            {
                string userID = User.Identity.GetUserId();  //get current userID
                var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();    //get user 
                var student = db.Students.Where(s => s.UserID == user.Id).FirstOrDefault(); //get the corresponding student
                var signIns = db.SignIns.Where(s => s.StudentID == student.ID).Include(s => s.Class).Include(s => s.Student);
                return View(signIns.ToList());
            }
            return RedirectToAction("Index", "Home");   
        }

        // GET: SignIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignIn signIn = db.SignIns.Find(id);
            if (signIn == null)
            {
                return HttpNotFound();
            }
            return View(signIn);
        }

        // GET: SignIns/Create
        public ActionResult Create()
        {
            string userID = User.Identity.GetUserId();  //get current userID
            var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();    //get user 
            var student = db.Students.Where(s => s.UserID == user.Id).FirstOrDefault(); //get the corresponding student
            ViewBag.ClassID = new SelectList(db.ClassStudents.Where(c => c.StudentID == student.ID), "ID", "Name");
            DateTime date = DateTime.Now;
            SignIn signIn = new SignIn()
            {
                Student = student,
                Date = date
            };
            return View(signIn);
        }

        // POST: SignIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,ClassID,Date,Late")] SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                string userID = User.Identity.GetUserId();  //get current userID
                var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();    //get user 
                var student = db.Students.Where(s => s.UserID == user.Id).FirstOrDefault(); //get the corresponding student
                DateTime signInTime = Convert.ToDateTime(signIn.Date.TimeOfDay);
                DateTime lateTime = Convert.ToDateTime("07:15:00");

                //if (lateTime <= DateTime.Now)
                if (DateTime.Now == Convert.ToDateTime("15:32:00"))
                {
                    SlackClientTest slackClient = new SlackClientTest();
                    slackClient.TestPostMessage();
                }

                if (signInTime > lateTime)
                {
                    signIn.Late = true;
                    db.SignIns.Add(signIn);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    signIn.Late = false;
                    db.SignIns.Add(signIn);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", signIn.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName", signIn.StudentID);
            return View(signIn);
        }

        // GET: SignIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignIn signIn = db.SignIns.Find(id);
            if (signIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", signIn.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName", signIn.StudentID);
            return View(signIn);
        }

        // POST: SignIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,ClassID,Date,Late")] SignIn signIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(signIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", signIn.ClassID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName", signIn.StudentID);
            return View(signIn);
        }

        // GET: SignIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SignIn signIn = db.SignIns.Find(id);
            if (signIn == null)
            {
                return HttpNotFound();
            }
            return View(signIn);
        }

        // POST: SignIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SignIn signIn = db.SignIns.Find(id);
            db.SignIns.Remove(signIn);
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
