using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.SignalR.Hubs;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class HumanVictimsController : Controller
    {
        private readonly HumanVictimRepository _humanVictimRepository = new HumanVictimRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CountiesRepository _countyRepository = new CountiesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();
       
        //Add and Edit        
        public ActionResult HumanVictimForm(string biteId,string victimId)
        {

            if (biteId == null)
            {
                return new HttpNotFoundResult("Please provide correct information");
            }

            if (victimId == null)
            {
                var newhumanVictimFormViewModel = new HumanVictimFormViewModel
                {
                    BiteId = biteId,
                    States = _statesRepository.GetStates(),
                    Counties = _countyRepository.GetCountiesByStateId(null),
                    Cities = _citiesRepository.GetCitiesByState(null)
                };

                return View(newhumanVictimFormViewModel);
            }

            var humanVictim = _humanVictimRepository.GetById(victimId).Result;

            if (humanVictim != null)
            {


                var humanVictimFormViewModel = Mapper.Map<HumanVictim, HumanVictimFormViewModel>(humanVictim);
                humanVictimFormViewModel.States = _statesRepository.GetStates();
                humanVictimFormViewModel.Counties =_countyRepository.GetCountiesByStateId(humanVictimFormViewModel.StateId);
                humanVictimFormViewModel.Cities = _citiesRepository.GetCitiesByState(humanVictimFormViewModel.StateId);

                return View(humanVictimFormViewModel);
            }
            return new HttpNotFoundResult("Cannot find the victim");
        }


        //Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(HumanVictimFormViewModel humanVictimViewModel)
        {
            if (ModelState.IsValid)
            {
                var humanVictim = Mapper.Map<HumanVictimFormViewModel, HumanVictim>(humanVictimViewModel);


                if (humanVictim.Id == null)
                {
                    await _humanVictimRepository.Insert(humanVictim);
                    TempData["Message"] = "Victim added successfully.";
                    TempData["MessageType"] = "success";
                }
                else
                {
                    await _humanVictimRepository.Update(humanVictim);
                    TempData["Message"] = "Victim updated successfully.";
                    TempData["MessageType"] = "success";
                }

                await _humanVictimRepository.SaveChangesAsync();
                return RedirectToAction("Details", "Bites", new { biteId = humanVictim.BiteId,animalId=ViewBag.AnimalId, Message = Constant.ManageMessageId.SaveHumanVictimDataSuccess });
            }


            humanVictimViewModel.States = _statesRepository.All();
            humanVictimViewModel.Counties = _countyRepository.All();
            humanVictimViewModel.Cities = _citiesRepository.All();
            
            return View("HumanVictimForm", humanVictimViewModel);
        }

        
        //Delete Confirmation
        public async Task<ActionResult> Delete(string victimId)
        {
            if (victimId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanVictim humanVictim = await _humanVictimRepository.GetById(victimId);
           

            if (humanVictim == null)
            {
                return HttpNotFound();
            }

            var humanVictimFormViewModel = Mapper.Map<HumanVictim, HumanVictimFormViewModel>(humanVictim);
            humanVictimFormViewModel.States = _statesRepository.All();
            humanVictimFormViewModel.Counties = _countyRepository.GetCountiesByStateId(humanVictimFormViewModel.StateId);
            humanVictimFormViewModel.Cities = _citiesRepository.GetCitiesByState(humanVictimFormViewModel.StateId);


            return View(humanVictimFormViewModel);
        }


        //Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string victimId)
        {
            HumanVictim humanVictim = await _humanVictimRepository.GetById(victimId);
            var biteId = humanVictim.BiteId;
            await _humanVictimRepository.DeleteAsync(humanVictim.Id);
            await _humanVictimRepository.SaveChangesAsync();
            TempData["Message"] = "Victim deleted successfully.";
            TempData["MessageType"] = "success";
            return RedirectToAction("Details","Bites",new { biteId = biteId });
        }

    }
}
