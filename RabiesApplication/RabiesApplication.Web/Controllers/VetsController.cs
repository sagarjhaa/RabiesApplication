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
    public class VetsController : Controller
    {
        //Todo Work on VetsController to include repository and actions

        private readonly VetRepository _vetRepository = new VetRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CountiesRepository _countyRepository = new CountiesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();


        // GET: Vets
        public ActionResult Index(int? pageNo)
        {
            var vets = _vetRepository.All().ToList();

            int sizeOfPage = 10;
            int noOfPage = (pageNo ?? 1);

            return View(vets.ToPagedList(noOfPage, sizeOfPage));
        }


        ////GET: Vets/Create
        public ActionResult VetForm(string vetId)
        {
            if (vetId == null)
            {
                var newVetFormViewModel = new VetFormViewModel()
                {
                    States = _statesRepository.GetStates(),
                    Counties = _countyRepository.GetCountiesByStateId(null),
                    Cities = _citiesRepository.GetCitiesByState(null)
                };

                return View(newVetFormViewModel);
            }


            var vet = _vetRepository.GetById(vetId).Result;
            if (vet == null)
            {
                return HttpNotFound("Vet details not available");
            }

            var vetFormViewModel = Mapper.Map<Vet, VetFormViewModel>(vet);
            vetFormViewModel.States = _statesRepository.GetStates();
            vetFormViewModel.Counties = _countyRepository.GetCountiesByStateId(vetFormViewModel.StateId);
            vetFormViewModel.Cities = _citiesRepository.GetCitiesByState(vetFormViewModel.StateId);
            
            return View(vetFormViewModel);
        }

        // POST: Vets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(VetFormViewModel vetFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var vet = Mapper.Map<VetFormViewModel, Vet>(vetFormViewModel);

                if (vet.Id == null)
                {
                    await _vetRepository.Insert(vet);
                }
                else
                {
                    await _vetRepository.Update(vet);
                }
                await _vetRepository.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            vetFormViewModel.States = _statesRepository.GetStates();
            vetFormViewModel.Counties = _countyRepository.GetCountiesByStateId(vetFormViewModel.StateId);
            vetFormViewModel.Cities = _citiesRepository.GetCitiesByState(vetFormViewModel.StateId);
            return View("VetForm",vetFormViewModel);
        }


        // GET: Vets/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = await _vetRepository.GetById(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            var vetFormViewModel = Mapper.Map<Vet,VetFormViewModel>(vet);
            vetFormViewModel.States = _statesRepository.GetStates();
            vetFormViewModel.Counties = _countyRepository.GetCountiesByStateId(vetFormViewModel.StateId);
            vetFormViewModel.Cities = _citiesRepository.GetCitiesByState(vetFormViewModel.StateId);

            return View(vetFormViewModel);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Vet vet = await _vetRepository.GetById(id);
            vet.Active = false;
            await _vetRepository.Update(vet);
            await _vetRepository.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }

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
