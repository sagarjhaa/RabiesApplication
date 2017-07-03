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
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class PetOwnersController : Controller
    {
        private readonly PetOwnerRepository _petOwnerRepository = new PetOwnerRepository();
        private readonly AnimalRepository _animalRepository = new AnimalRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CountiesRepository _countyRepository = new CountiesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();

      
        // GET: PetOwners/Create
        public ActionResult PetOwnerForm(string animalId,string ownerId)
        {
            var petOwnerViewModel = new PetOwnerViewModel()
            {
                PetOwner = new PetOwner(),
                Animal =  _animalRepository.GetById(animalId).Result,
                States = _statesRepository.All(),
                Counties = _countyRepository.All(),
                Cities = _citiesRepository.All()
            };


            if (animalId != null)
            {
                petOwnerViewModel.PetOwner = _petOwnerRepository.GetById(ownerId).Result;
                    //GetOwnerByAnimalId(animalId);
            }
            
            return View(petOwnerViewModel);
        }

        // POST: PetOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(PetOwner petOwner)
        {
            ModelState.Remove("RecordCreated");

            if (ModelState.IsValid)
            {
                await _petOwnerRepository.InsertOrUpdateAsync(petOwner);
                await _petOwnerRepository.SaveChangesAsync();
                var biteId = _animalRepository.GetById(petOwner.AnimalId).Result.BiteId;
                return RedirectToAction("Details","Bites",new { biteId = biteId});
            }

            var petOwnerViewModel = new PetOwnerViewModel()
            {
                PetOwner = petOwner,
                Animal = _animalRepository.GetById(petOwner.AnimalId).Result,
                States = _statesRepository.All(),
                Counties = _countyRepository.All(),
                Cities = _citiesRepository.All()
            };
            return View("PetOwnerForm", petOwnerViewModel);
        }

        // GET: PetOwners/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetOwner petOwner = await _petOwnerRepository.GetById(id);
            if (petOwner == null)
            {
                return HttpNotFound();
            }
            return View(petOwner);
        }

        // POST: PetOwners/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    PetOwner petOwner = await db.PetOwners.FindAsync(id);
        //    db.PetOwners.Remove(petOwner);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
