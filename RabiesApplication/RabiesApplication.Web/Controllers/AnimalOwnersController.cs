using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RabiesApplication.Models;
using RabiesApplication.Web;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class AnimalOwnersController : Controller
    {
        
        private readonly AnimalOwnerRepository _animalOwnerRepository = new AnimalOwnerRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CountiesRepository _countyRepository = new CountiesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();


    

        // GET: AnimalOwners/Create
        public ActionResult AnimalOwnerForm(string animalOwnerId,string biteId)
        {
            @ViewBag.BiteId = biteId;
            if (animalOwnerId == null)
            {
                var newanimalOwnerFormViewModel = new AnimalOwnerFormViewModel()
                {
                    States = _statesRepository.GetStates(),
                    Counties = _countyRepository.GetCountiesByStateId(null),
                    Cities = _citiesRepository.GetCitiesByState(null)
                };

                return View("AnimalOwnerForm",newanimalOwnerFormViewModel);
            }


            var animalOwnerFormViewModelDb = _animalOwnerRepository.GetById(animalOwnerId).Result;

            if (animalOwnerFormViewModelDb == null)
            {
                return null;
            }


            var animalOwnerFormViewModel = Mapper.Map<AnimalOwner, AnimalOwnerFormViewModel>(animalOwnerFormViewModelDb);
            animalOwnerFormViewModel.States = _statesRepository.GetStates();
            animalOwnerFormViewModel.Counties = _countyRepository.GetCountiesByStateId(null);
            animalOwnerFormViewModel.Cities = _citiesRepository.GetCitiesByState(null);

            return View("AnimalOwnerForm",animalOwnerFormViewModel);
        }

        //// POST: AnimalOwners/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Save(AnimalOwner animalOwner)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.AnimalOwner.Add(animalOwner);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", animalOwner.CityId);
        //    ViewBag.StateId = new SelectList(db.States, "Id", "StateName", animalOwner.StateId);
        //    return View(animalOwner);
        //}


        //// GET: AnimalOwners/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AnimalOwner animalOwner = await db.AnimalOwner.FindAsync(id);
        //    if (animalOwner == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(animalOwner);
        //}

        //// POST: AnimalOwners/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    AnimalOwner animalOwner = await db.AnimalOwner.FindAsync(id);
        //    db.AnimalOwner.Remove(animalOwner);
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
