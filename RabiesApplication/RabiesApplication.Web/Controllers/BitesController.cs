using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using RabiesApplication.Models;
using RabiesApplication.Web.BusinessLogic;
using RabiesApplication.Web.Hubs;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;
using Action = RabiesApplication.Models.Action;

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
        private readonly PetOwnerRepository _petOwnerRepository = new PetOwnerRepository();
        private readonly ActionRepository _actionRepository = new ActionRepository();

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
                //await _biteRepository.InsertOrUpdateAsync(bite);
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

                //ComposeLetter.TenDayQuarantineLetter();

                return RedirectToAction("Details",new {biteId = bite.Id,Message = Constant.ManageMessageId.SavedBiteDataSuccess});
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
        public async Task<ActionResult> Details(string biteId, Constant.ManageMessageId? message)
        {
            

            ViewBag.StatusMessage =
                  message == Constant.ManageMessageId.SavedBiteDataSuccess ? "Bite data saved successfully."
                : message == Constant.ManageMessageId.SaveHumanVictimDataSuccess ? "Victim data saved successfully."
                : message == Constant.ManageMessageId.DeleteHumanVictimSuccess ? "Victim deleted successfully."
                : message == Constant.ManageMessageId.ErrorHumanVictimData ? "Error saving Victim data."
                : message == Constant.ManageMessageId.SavePetVictimDataSuccess ? "Pet data saved successfully"
                : message == Constant.ManageMessageId.DeletePetVictimSuccess ? "Pet data deleted successfully"
                : "";


            if (biteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bite bite =await _biteRepository.GetById(biteId);
            if (bite == null)
            {
                return HttpNotFound();
            }

            var bitedetailsViewModel = new BiteDetailsViewModel
            {
                Bite = bite,
                HumanVictims = _humanVictimRepository.GetAllByBiteId(biteId),
                Pets = _animalRepository.GetAllPetVictims(biteId),
                Animal = _animalRepository.GetAnimalByBiteId(biteId),
                PetOwner = bite.Animals.First(a => a.IsVictim.Equals(false)).PetOwner,
                Actions = _actionRepository.GetActionsByBiteId(biteId)
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
            _biteRepository.Update(bite);
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

        public ActionResult GenerateLetter(string biteId,FormCollection form)
        {
            if (biteId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bite = _biteRepository.GetById(biteId).Result;

            if (bite == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var selectedLetter = form["Letter Type"];

            new ComposeLetter(bite).TenDayQuarantineLetterDifferent();

            int result;
            int.TryParse(selectedLetter, out result);
            ActionsHelper.SaveActions(ActionsHelper.GenerateSendLetterAction(biteId, result));
            return RedirectToAction("Details", new { biteId = bite.Id});

        }


       

        
    }
}
