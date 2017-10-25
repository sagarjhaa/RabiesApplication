using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabiesApplication.Models;
using RabiesApplication.Web;

namespace RabiesApplication.Web.Controllers
{
    public class AnimalOwnersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AnimalOwners
        public async Task<ActionResult> Index()
        {
            var animalOwner = db.AnimalOwner.Include(a => a.City).Include(a => a.State);
            return View(await animalOwner.ToListAsync());
        }

        // GET: AnimalOwners/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalOwner animalOwner = await db.AnimalOwner.FindAsync(id);
            if (animalOwner == null)
            {
                return HttpNotFound();
            }
            return View(animalOwner);
        }

        // GET: AnimalOwners/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName");
            return View();
        }

        // POST: AnimalOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IsShelter,FirstName,LastName,Dateofbirth,Age,Addressline1,Addressline2,CityId,CountyId,StateId,Zipcode,Contactnumber1,Contactnumber2,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] AnimalOwner animalOwner)
        {
            if (ModelState.IsValid)
            {
                db.AnimalOwner.Add(animalOwner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", animalOwner.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", animalOwner.StateId);
            return View(animalOwner);
        }

        // GET: AnimalOwners/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalOwner animalOwner = await db.AnimalOwner.FindAsync(id);
            if (animalOwner == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", animalOwner.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", animalOwner.StateId);
            return View(animalOwner);
        }

        // POST: AnimalOwners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IsShelter,FirstName,LastName,Dateofbirth,Age,Addressline1,Addressline2,CityId,CountyId,StateId,Zipcode,Contactnumber1,Contactnumber2,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] AnimalOwner animalOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalOwner).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", animalOwner.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", animalOwner.StateId);
            return View(animalOwner);
        }

        // GET: AnimalOwners/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalOwner animalOwner = await db.AnimalOwner.FindAsync(id);
            if (animalOwner == null)
            {
                return HttpNotFound();
            }
            return View(animalOwner);
        }

        // POST: AnimalOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            AnimalOwner animalOwner = await db.AnimalOwner.FindAsync(id);
            db.AnimalOwner.Remove(animalOwner);
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
