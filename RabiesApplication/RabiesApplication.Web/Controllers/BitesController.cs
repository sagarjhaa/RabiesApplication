using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RabiesApplication.Models;
using RabiesApplication.Web;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class BitesController : Controller
    {
        
        private readonly BiteRepository _biteRepository = new BiteRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly BiteStatusRepository _biteStatusRepository = new BiteStatusRepository();

        private readonly HumanVictimRepository _humanVictimRepository = new HumanVictimRepository();

        private readonly AnimalRepository _animalRepository = new AnimalRepository();
        private readonly BreedRepository _breedRepository = new BreedRepository();
        private readonly SpeciesRepository _speciesRepository = new SpeciesRepository();
        private readonly VetRepository _vetRepository = new VetRepository();

        // GET: Bites
        public ActionResult Index()
        {
            var bites = _biteRepository.All();
            return View(bites.ToList());
        }

        public async Task<ActionResult> BiteForm(string id)
        {
           
            var biteViewModel = new BiteViewModel
            {
                Bite = new Bite(),
                Cities = _citiesRepository.All(),
                States = _statesRepository.All(),
                Employees = _employeeRepository.All(),
                BiteStatuses = _biteStatusRepository.All()
            };

            if (id != null)
            {
                biteViewModel.Bite = await _biteRepository.GetById(id);

                
                if (biteViewModel.Bite == null)
                {
                    return HttpNotFound();
                }

            }

            return View(biteViewModel);
        }


        // POST: Bites/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Bite bite)
        {
            //Remove checking on EmployeecreatedId
            //ModelState.Remove("EmployeecreatedId");


            if (ModelState.IsValid)
            {
                await _biteRepository.InsertOrUpdateAsync(bite);
                await _biteRepository.SaveChangesAsync();
                return RedirectToAction("Details",new {id = bite.Id,Message = Constant.ManageMessageId.SavedBiteDataSuccess});
            }

            var biteViewModel = new BiteViewModel
            {
                Bite = bite,
                Cities = _citiesRepository.All(),
                States = _statesRepository.All(),
                Employees = _employeeRepository.All(),
                BiteStatuses = _biteStatusRepository.All()
            };

            return View("BiteForm", biteViewModel);
        }


        // GET: Bites/Details/5
        public async Task<ActionResult> Details(string id, Constant.ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                  message == Constant.ManageMessageId.SavedBiteDataSuccess ? "Bite data saved successfully."
                : message == Constant.ManageMessageId.AddHumanVictimSuccess ? "Human victim added successfully."
                : message == Constant.ManageMessageId.EditHumanVictimSuccess ? "Human victim edited successfully."
                : message == Constant.ManageMessageId.DeleteHumanVictimSuccess ? "Human victim deleted successfully"
                : "";


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bite bite =await _biteRepository.GetById(id);
            if (bite == null)
            {
                return HttpNotFound();
            }

            var bitedetailsViewModel = new BiteDetailsViewModel
            {
                Bite = bite,
                HumanVictims = _humanVictimRepository.GetAllByBiteId(id),
                States = _statesRepository.All(),
                Cities = _citiesRepository.All(),
                Employees = _employeeRepository.All(),

                Animal = _animalRepository.GetAllPetVictims(id),
                Breeds = _breedRepository.All(),
                Specieses = _speciesRepository.All(),
                Vets = _vetRepository.All()
            };


            return View(bitedetailsViewModel);
        }

        // GET: Bites/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bite bite =_biteRepository.GetById(id).Result;
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
            Bite bite = _biteRepository.GetById(id).Result;
            bite.Active = Constant.Deactive;
            _biteRepository.InsertOrUpdateAsync(bite);
            _biteRepository.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        // GET: Bites/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bite bite = db.Bites.Find(id);
        //    if (bite == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bite);
        //}


        
    }
}
