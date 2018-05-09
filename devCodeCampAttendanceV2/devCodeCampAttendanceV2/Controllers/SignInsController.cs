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
    public class SignInsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SignIns
        public ActionResult Index()
        {
            var signIns = db.SignIns.Include(s => s.Class).Include(s => s.Student);
            return View(signIns.ToList());
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
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FirstName");
            return View();
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
                db.SignIns.Add(signIn);
                db.SaveChanges();
                return RedirectToAction("Index");
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
