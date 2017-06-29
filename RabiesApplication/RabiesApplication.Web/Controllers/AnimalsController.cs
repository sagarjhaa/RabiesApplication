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
    public class AnimalsController : Controller
    {
        private DataContext db = new DataContext();


        // GET: Animals/Create
        public ActionResult Create(string id)
        {
            ViewBag.BiteId = new SelectList(db.Bites, "Id", "CityId");
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Description");
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "Description");
            ViewBag.VetId = new SelectList(db.Vets, "Id", "FirstName");

            if (id != null)
            {
                
            }


            return View();
        }

        // POST: Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BiteId = new SelectList(db.Bites, "Id", "CityId", animal.BiteId);
            ViewBag.BreedId = new SelectList(db.Breeds, "Id", "Description", animal.BreedId);
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "Description", animal.SpeciesId);
            ViewBag.VetId = new SelectList(db.Vets, "Id", "FirstName", animal.VetId);
            return View(animal);
        }

       
        // GET: Animals/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Animal animal = await db.Animals.FindAsync(id);
            db.Animals.Remove(animal);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

      
    }
}
