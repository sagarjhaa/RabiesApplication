using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using RabiesApplication.Models;
//using RabiesApplication.Web.BusinessLogic;
using RabiesApplication.Web.Hubs;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;
using Action = RabiesApplication.Models.Action;
using PagedList;

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
        private readonly VetRepository _vetRepository = new VetRepository();
        //private readonly PetOwnerRepository _petOwnerRepository = new PetOwnerRepository();
        //private readonly ActionRepository _actionRepository = new ActionRepository();

        // GET: Bites
        public ActionResult Index(int? pageNo)
        {
            var bites = _biteRepository.GetBiteIndexView(); //All().ToList();

            int sizeOfPage = 10;
            int noOfPage = (pageNo ?? 1);

            return View(bites.ToPagedList(noOfPage,sizeOfPage));
        }

        public async Task<ActionResult> BiteForm(string id)
        {
            if (id == null)
            {
                var newBiteViewModel = new BiteViewModel()
                {
                    States = _statesRepository.All(),
                    Cities = _citiesRepository.GetCitiesByState(null),
                    Employees = _employeeRepository.All(),
                    BiteStatuses = _biteStatusRepository.All()
                };

                return View(newBiteViewModel);
            }
           
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
                biteViewModel.States = _statesRepository.All().OrderBy(s => s.StateName);
                biteViewModel.Cities = _citiesRepository.GetCitiesByState(biteViewModel.Bite.StateId);

                
                if (biteViewModel.Bite == null)
                {
                    return HttpNotFound();
                }

            }

            return View(biteViewModel);
        }



        public JsonResult  GetCitiesByStateId(string stateId)
        {
            var cities = _citiesRepository.GetCitiesByState(stateId);
            return  Json(cities,JsonRequestBehavior.AllowGet);
        }


        public ViewResult Details(string biteId,string animalId)
        {


            var bite = _biteRepository.GetBiteJustViewModel(biteId);
            var animal = _animalRepository.GetAnimalByBiteId(bite.Id, animalId);
            var humanVicitm = _humanVictimRepository.GetHumanVictimViewModelByBiteId(bite.Id);
            var vet = _vetRepository.GetVetDetails(animalId);

            var ctx = new DataContext();
            var animalOwner = (from o in ctx.AnimalOwner
                where o.Id.Equals(animal.OwnerId)
                join s in ctx.States on o.StateId equals s.Id
                join c in ctx.Cities on o.CityId equals c.Id
                select new AnimalOwnerViewModel()
                {
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Id = o.Id,
                    Zip = o.Zipcode.ToString(),
                    State = s.StateName,
                    City = c.CityName
                }).FirstOrDefault();

            var bitedetailsViewModel = new BiteDetailsViewModel
            {
                Bite = bite,
                Animal = animal,
                HumanVictims = humanVicitm,
                AnimalOwner = animalOwner,
                Vet = vet
            };


            return View(bitedetailsViewModel);
            //return Json(bitedetailsViewModel, JsonRequestBehavior.AllowGet);
        }



        // POST: Bites/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Bite bite)
        {
            if (ModelState.IsValid)
            {
                if (bite.Id == null)
                {
                    await _biteRepository.Insert(bite);
                }
                else
                {
                    await _biteRepository.Update(bite);
                }
                await _biteRepository.SaveChangesAsync();

                //var biteupdate = new BiteUpdatesHub();
                //await biteupdate.NotifyUpdates();

                return RedirectToAction("Index");
                //return RedirectToAction("Details", new { biteId = bite.Id, Message = Constant.ManageMessageId.SavedBiteDataSuccess });
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


        //// GET: Bites/Details/5
        //public async Task<ActionResult> Details(string biteId, Constant.ManageMessageId? message)
        //{


        //    ViewBag.StatusMessage =
        //          message == Constant.ManageMessageId.SavedBiteDataSuccess ? "Bite data saved successfully."
        //        : message == Constant.ManageMessageId.SaveHumanVictimDataSuccess ? "Victim data saved successfully."
        //        : message == Constant.ManageMessageId.DeleteHumanVictimSuccess ? "Victim deleted successfully."
        //        : message == Constant.ManageMessageId.ErrorHumanVictimData ? "Error saving Victim data."
        //        : message == Constant.ManageMessageId.SavePetVictimDataSuccess ? "Pet data saved successfully"
        //        : message == Constant.ManageMessageId.DeletePetVictimSuccess ? "Pet data deleted successfully"
        //        : "";


        //    if (biteId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bite bite =await _biteRepository.GetById(biteId);
        //    if (bite == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var bitedetailsViewModel = new BiteDetailsViewModel
        //    {
        //        Bite = bite,
        //        HumanVictims = _humanVictimRepository.GetAllByBiteId(biteId),
        //        Pets = _animalRepository.GetAllPetVictims(biteId),
        //        Animal = _animalRepository.GetAnimalByBiteId(biteId),
        //        PetOwner = bite.Animals.First(a => a.IsVictim.Equals(false)).PetOwner,
        //        Actions = _actionRepository.GetActionsByBiteId(biteId)
        //    };

        //    return View(bitedetailsViewModel);
        //}

        //// GET: Bites/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bite bite =_biteRepository.GetById(id).Result;
        //    if (bite == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bite);
        //}

        //// POST: Bites/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Bite bite = _biteRepository.GetById(id).Result;
        //    bite.Active = Constant.Deactive;
        //    _biteRepository.Update(bite);
        //    _biteRepository.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}


        //// GET: Bites/Details/5
        ////public ActionResult Details(string id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    Bite bite = db.Bites.Find(id);
        ////    if (bite == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(bite);
        ////}

        //public ActionResult GenerateLetter(string biteId,FormCollection form)
        //{
        //    if (biteId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }



        //    var selectedLetter = form["Letter Type"];


        //    try
        //    {
        //        int result;
        //        int.TryParse(selectedLetter, out result);
        //        ActionsHelper.SaveActions(ActionsHelper.GenerateSendLetterAction(biteId, result));
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }





        //    return RedirectToAction("Details", new { biteId = biteId});

        //}


        //public FileStreamResult GetDocument(string documentId)
        //{
        //    string path = HttpContext.Server.MapPath("~") + "LettersSent\\" + documentId;
        //    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    return File(fs, "application/vnd.openxmlformats-officedocument.wordprocessingml.document",documentId);
        //}


    }
}
