﻿using System;
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
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName");
            return View();
        }

        // POST: ClassStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,StudentID")] ClassStudent classStudent)
        {
            if (ModelState.IsValid)
            {
                db.ClassStudents.Add(classStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
        public ActionResult Delete(int? id)
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

        // POST: ClassStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassStudent classStudent = db.ClassStudents.Find(id);
            db.ClassStudents.Remove(classStudent);
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
