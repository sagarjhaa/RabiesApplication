using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using RabiesApplication.Models;
//using RabiesApplication.Web.BusinessLogic;
using RabiesApplication.Web.Hubs;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;
using Action = RabiesApplication.Models.Action;
using PagedList;
using RabiesApplication.Web.BusinessLogic;

namespace RabiesApplication.Web.Controllers
{
    public class BitesController : Controller
    {
        
        private readonly BiteRepository _biteRepository = new BiteRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();
        private readonly CountiesRepository _countiesRepository = new CountiesRepository();
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly BiteStatusRepository _biteStatusRepository = new BiteStatusRepository();
        private readonly HumanVictimRepository _humanVictimRepository = new HumanVictimRepository();
        private readonly AnimalRepository _animalRepository = new AnimalRepository();
        private readonly AnimalOwnerRepository _animalOwnerRepository = new AnimalOwnerRepository();
        private readonly VetRepository _vetRepository = new VetRepository();
        private readonly ActionRepository _actionRepository = new ActionRepository();


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
                var newBiteViewModel = new BiteFormViewModel()
                {
                    States = _statesRepository.All(),
                    Cities = _citiesRepository.GetCitiesByState(null),
                    Employees = _employeeRepository.GetEmployeeDict(),
                    BiteStatuses = _biteStatusRepository.All()
                };

                return View(newBiteViewModel);
            }
           
            var biteDb = await _biteRepository.GetById(id);

            if (biteDb == null)
            {
                return HttpNotFound();
            }
            
            
            var biteViewModel = Mapper.Map<Bite,BiteFormViewModel>(biteDb);
            biteViewModel.Employees = _employeeRepository.GetEmployeeDict();
            biteViewModel.BiteStatuses = _biteStatusRepository.All();
            biteViewModel.States = _statesRepository.All().OrderBy(s => s.StateName);
            biteViewModel.Cities = _citiesRepository.GetCitiesByState(biteDb.StateId);

           

            return View(biteViewModel);
        }

        public ViewResult Details(string biteId,string animalId)
        {


            var bite = _biteRepository.GetBiteJustViewModel(biteId);
            var humanVicitm = _humanVictimRepository.GetHumanVictimViewModelByBiteId(bite.Id);
            var animal = _animalRepository.GetAnimalByBiteId(bite.Id, animalId);
            var actions = _actionRepository.GetActionsByBiteId(biteId).Take(5);

            VetViewModel vet = null;
            AnimalOwnerViewModel animalOwner = null;
            if (animal != null)
            {
                animalOwner = _animalOwnerRepository.GetOwnerByAnimalId(animal.OwnerId);
                vet = _vetRepository.GetVetDetails(animal.Id);
            }
            

            var bitedetailsViewModel = new BiteDetailsViewModel
            {
                Bite = bite,
                Animal = animal,
                HumanVictims = humanVicitm,
                AnimalOwner = animalOwner,
                Vet = vet,
                Actions = actions
            };


            return View(bitedetailsViewModel);
            //return Json(bitedetailsViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(BiteFormViewModel biteViewModel)
        {
            if (ModelState.IsValid)
            {
                var bite = Mapper.Map<BiteFormViewModel, Bite>(biteViewModel);

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



            biteViewModel.Cities = _citiesRepository.All();
            biteViewModel.States = _statesRepository.All();
            biteViewModel.Employees = _employeeRepository.GetEmployeeDict();
            biteViewModel.BiteStatuses = _biteStatusRepository.All();

            return View("BiteForm", biteViewModel);
        }


        //Todo: Need to work on bite delete(Disable) function



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

        public ActionResult GenerateLetter(string biteId,string animalId, FormCollection form)
        {
            if (biteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var selectedLetter = form["Letter Type"];
            try
            {
                int result;
                int.TryParse(selectedLetter, out result);
                new GenerateLetter().GenerateSendLetterAction(biteId, animalId, result);

                TempData["MessageType"] = Constant.Success;
                TempData["Message"] = "Letter is generated and Reminder is set.";

            }
            catch (Exception ex)
            {
                TempData["MessageType"] = Constant.Error;
                TempData["Message"] = "Error occurred !!!. " + ex.Message ;
            }
            return RedirectToAction("Details", new { biteId = biteId });
        }


        public string GetPath(string documentId)
        {
            if (documentId == null)
            {
                return "Not Found";

            }

            return  Server.MapPath("~") + "LettersSent\\" + documentId;
        }

        public ActionResult DocumentDownload(string documentId)
        {
            if (documentId == null)
            {
                return HttpNotFound("Wrong data");

            }

            var document = _actionRepository.Context.Actions.First(a => a.DocumentId.Equals(documentId.Trim()));
            if(document == null)
            {
                return HttpNotFound("Document not found");
            }

           string documentSavePath = Server.MapPath("~") + "LettersSent\\" + documentId;
           byte[] fileBytes = System.IO.File.ReadAllBytes(documentSavePath);
           return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet,"Document.jpeg");

        }



        public ActionResult OpenReportWithNoDetails(int? pageNo,string reportName)
        {
            ViewBag.reportName = reportName;

            var bites = new List<BiteDetailViewModel>();
            if (reportName.Equals("OpenReportWithNoDetails"))
            {
                 bites = (List<BiteDetailViewModel>) _biteRepository.OpenReportWithNoDetails();
            }
            else if (reportName.Equals("OpenReportWithNoQuarantine"))
            {
                 bites = (List<BiteDetailViewModel>) _biteRepository.OpenReportWithNoQuarantine();
            }
            else if (reportName.Equals("OpenReportWithNoVaccination"))
            {
                 bites = (List<BiteDetailViewModel>) _biteRepository.OpenReportWithNoVaccination();
            }

            int sizeOfPage = 10;
            int noOfPage = (pageNo ?? 1);

            return View(bites.ToPagedList(noOfPage, sizeOfPage));
        }




        public JsonResult GetCitiesByStateId(string stateId)
        {
            var cities = _citiesRepository.GetCitiesByState(stateId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountiesByStateId(string stateId)
        {
            var counties = _countiesRepository.GetCountiesByStateId(stateId);
            return Json(counties, JsonRequestBehavior.AllowGet);
        }

    }
}
