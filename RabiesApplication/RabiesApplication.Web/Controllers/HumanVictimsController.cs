using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabiesApp.Models;
using RabiesApplication.Web;

namespace RabiesApplication.Web.Controllers
{
    public class HumanVictimsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: HumanVictims
        public async Task<ActionResult> Index()
        {
            var humanVictims = db.HumanVictims.Include(h => h.Bite).Include(h => h.City).Include(h => h.County).Include(h => h.State);
            return View(await humanVictims.ToListAsync());
        }

        // GET: HumanVictims/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanVictim humanVictim = await db.HumanVictims.FindAsync(id);
            if (humanVictim == null)
            {
                return HttpNotFound();
            }
            return View(humanVictim);
        }

        // GET: HumanVictims/Create
        public ActionResult Create()
        {
            ViewBag.BiteId = new SelectList(db.Bites, "Id", "CityId");
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "Name");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName");
            return View();
        }

        // POST: HumanVictims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RowVersion,BiteId,FirstName,LastName,Dateofbirth,Age,Addressline1,Addressline2,CityId,CountyId,StateId,Zipcode,Contactnumber1,Contactnumber2,BiteType,BiteTypeNonBite,PostExposureProphylaxis,MedicalTreatmentProvider,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] HumanVictim humanVictim)
        {
            if (ModelState.IsValid)
            {
                db.HumanVictims.Add(humanVictim);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BiteId = new SelectList(db.Bites, "Id", "CityId", humanVictim.BiteId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", humanVictim.CityId);
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "Name", humanVictim.CountyId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", humanVictim.StateId);
            return View(humanVictim);
        }

        // GET: HumanVictims/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanVictim humanVictim = await db.HumanVictims.FindAsync(id);
            if (humanVictim == null)
            {
                return HttpNotFound();
            }
            ViewBag.BiteId = new SelectList(db.Bites, "Id", "CityId", humanVictim.BiteId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", humanVictim.CityId);
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "Name", humanVictim.CountyId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", humanVictim.StateId);
            return View(humanVictim);
        }

        // POST: HumanVictims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RowVersion,BiteId,FirstName,LastName,Dateofbirth,Age,Addressline1,Addressline2,CityId,CountyId,StateId,Zipcode,Contactnumber1,Contactnumber2,BiteType,BiteTypeNonBite,PostExposureProphylaxis,MedicalTreatmentProvider,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] HumanVictim humanVictim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(humanVictim).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BiteId = new SelectList(db.Bites, "Id", "CityId", humanVictim.BiteId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", humanVictim.CityId);
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "Name", humanVictim.CountyId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", humanVictim.StateId);
            return View(humanVictim);
        }

        // GET: HumanVictims/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanVictim humanVictim = await db.HumanVictims.FindAsync(id);
            if (humanVictim == null)
            {
                return HttpNotFound();
            }
            return View(humanVictim);
        }

        // POST: HumanVictims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            HumanVictim humanVictim = await db.HumanVictims.FindAsync(id);
            db.HumanVictims.Remove(humanVictim);
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
