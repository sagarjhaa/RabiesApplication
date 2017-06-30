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
using RabiesApplication.Web.Repositories;

namespace RabiesApplication.Web.Controllers
{
    public class PetOwnersController : Controller
    {
        private readonly PetOwnerRepository _petOwnerRepository = new PetOwnerRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CountiesRepository _countyRepository = new CountiesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();

      
        // GET: PetOwners/Create
        public ActionResult PetOwnerForm()
        {
            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "BiteId");
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName");
            return View();
        }

        // POST: PetOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                db.PetOwners.Add(petOwner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalId = new SelectList(db.Animals, "Id", "BiteId", petOwner.AnimalId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", petOwner.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", petOwner.StateId);
            return View(petOwner);
        }

        // GET: PetOwners/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOwner petOwner = await db.PetOwners.FindAsync(id);
            if (petOwner == null)
            {
                return HttpNotFound();
            }
            return View(petOwner);
        }

        // POST: PetOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PetOwner petOwner = await db.PetOwners.FindAsync(id);
            db.PetOwners.Remove(petOwner);
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
