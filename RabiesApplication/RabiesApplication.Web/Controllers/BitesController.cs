using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabiesApplication.Models;
using RabiesApplication.Web;

namespace RabiesApplication.Web.Controllers
{
    public class BitesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Bites
        public ActionResult Index()
        {
            var bites = db.Bites.Include(b => b.BiteStatus).Include(b => b.City).Include(b => b.State);
            return View(bites.ToList());
        }

        // GET: Bites/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bite bite = db.Bites.Find(id);
            if (bite == null)
            {
                return HttpNotFound();
            }
            return View(bite);
        }

        // GET: Bites/Create
        public ActionResult Create()
        {
            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description");
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName");
            return View();
        }

        // POST: Bites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RowVersion,CityId,StateId,BiteDate,BiteReportDate,BiteReportedBy,BiteStatusId,Comments,EmployeeAssignedId,Active,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] Bite bite)
        {
            if (ModelState.IsValid)
            {
                db.Bites.Add(bite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description", bite.BiteStatusId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", bite.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", bite.StateId);
            return View(bite);
        }

        // GET: Bites/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bite bite = db.Bites.Find(id);
            if (bite == null)
            {
                return HttpNotFound();
            }
            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description", bite.BiteStatusId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", bite.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", bite.StateId);
            return View(bite);
        }

        // POST: Bites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RowVersion,CityId,StateId,BiteDate,BiteReportDate,BiteReportedBy,BiteStatusId,Comments,EmployeeAssignedId,Active,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] Bite bite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description", bite.BiteStatusId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", bite.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", bite.StateId);
            return View(bite);
        }

        // GET: Bites/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bite bite = db.Bites.Find(id);
            if (bite == null)
            {
                return HttpNotFound();
            }
            return View(bite);
        }

        // POST: Bites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bite bite = db.Bites.Find(id);
            db.Bites.Remove(bite);
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
