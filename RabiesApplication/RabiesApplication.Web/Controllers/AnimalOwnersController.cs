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
using PagedList;
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


        public ActionResult AnimalOwners(int? pageNo)
        {
            var animalOwners = _animalOwnerRepository.All().ToList();

            int sizeOfPage = 10;
            int noOfPage = (pageNo ?? 1);

            return View(animalOwners.ToPagedList(noOfPage, sizeOfPage));
        }

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
            animalOwnerFormViewModel.Counties = _countyRepository.GetCountiesByStateId(animalOwnerFormViewModel.StateId);
            animalOwnerFormViewModel.Cities = _citiesRepository.GetCitiesByState(animalOwnerFormViewModel.StateId);
            animalOwnerFormViewModel.AnimalList = GetAnimalsByOwnerId(animalOwnerId);

            return View("AnimalOwnerForm",animalOwnerFormViewModel);
        }

        // POST: AnimalOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(AnimalOwnerFormViewModel animalOwnerFormViewModel)
        {
            var PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();

            if (ModelState.IsValid)
            {

                var animalOwner = Mapper.Map<AnimalOwnerFormViewModel, AnimalOwner>(animalOwnerFormViewModel);

                if (animalOwner.Id == null)
                {
                    await _animalOwnerRepository.Insert(animalOwner);
                }
                else
                {
                    await _animalOwnerRepository.Update(animalOwner);
                }

                await _animalOwnerRepository.SaveChangesAsync();

                var biteId= Request.QueryString["biteId"];

                if (biteId == null)
                {
                    return RedirectToAction("Index", "Bites");
                }
                return RedirectToAction("AnimalForm", "Animals", new {biteId = biteId});
            }

            animalOwnerFormViewModel.States = _statesRepository.GetStates();
            animalOwnerFormViewModel.Counties = _countyRepository.GetCountiesByStateId(null);
            animalOwnerFormViewModel.Cities = _citiesRepository.GetCitiesByState(null);

            return View("AnimalOwnerForm",animalOwnerFormViewModel);
        }


        public IEnumerable<AnimalListByOwner> GetAnimalsByOwnerId(string animalOwnerId)
        {
            return _animalOwnerRepository.GetAnimalsByOwnerId(animalOwnerId);
        }

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
