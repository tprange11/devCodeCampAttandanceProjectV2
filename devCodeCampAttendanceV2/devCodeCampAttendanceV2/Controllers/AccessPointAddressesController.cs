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
    public class AccessPointAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AccessPointAddresses
        public ActionResult Index()
        {
            return View(db.AccessPointAddresses.ToList());
        }

        // GET: AccessPointAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessPointAddress accessPointAddress = db.AccessPointAddresses.Find(id);
            if (accessPointAddress == null)
            {
                return HttpNotFound();
            }
            return View(accessPointAddress);
        }

        // GET: AccessPointAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccessPointAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AccessPointName,MAC")] AccessPointAddress accessPointAddress)
        {
            if (ModelState.IsValid)
            {
                db.AccessPointAddresses.Add(accessPointAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessPointAddress);
        }

        // GET: AccessPointAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessPointAddress accessPointAddress = db.AccessPointAddresses.Find(id);
            if (accessPointAddress == null)
            {
                return HttpNotFound();
            }
            return View(accessPointAddress);
        }

        // POST: AccessPointAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AccessPointName,MAC")] AccessPointAddress accessPointAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessPointAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessPointAddress);
        }

        // GET: AccessPointAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessPointAddress accessPointAddress = db.AccessPointAddresses.Find(id);
            if (accessPointAddress == null)
            {
                return HttpNotFound();
            }
            return View(accessPointAddress);
        }

        // POST: AccessPointAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessPointAddress accessPointAddress = db.AccessPointAddresses.Find(id);
            db.AccessPointAddresses.Remove(accessPointAddress);
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
