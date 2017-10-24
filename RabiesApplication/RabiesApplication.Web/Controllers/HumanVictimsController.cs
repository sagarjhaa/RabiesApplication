using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
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
       
        // GET: HumanVictims/Create
        public ActionResult HumanVictimForm(string biteId,string victimId)
        {
            var humanVictimFormViewModel = new HumanVictimFormViewModel
            {
                BiteId = biteId,
                States = _statesRepository.All()
            };

            if (victimId != null)
            {
                var humanVictim = _humanVictimRepository.GetById(victimId).Result;

                humanVictimFormViewModel.Id = humanVictim.Id;
                humanVictimFormViewModel.FirstName = humanVictim.FirstName;
                humanVictimFormViewModel.LastName = humanVictim.LastName;
                humanVictimFormViewModel.Addressline1 = humanVictim.Addressline1;
                humanVictimFormViewModel.Addressline2 = humanVictim.Addressline2;
                humanVictimFormViewModel.CityId = humanVictim.CityId;
                humanVictimFormViewModel.CountyId = humanVictim.CountyId;
                humanVictimFormViewModel.StateId = humanVictim.StateId;
                humanVictimFormViewModel.Zipcode = humanVictim.Zipcode;
                humanVictimFormViewModel.Contactnumber1 = humanVictim.Contactnumber1;
                humanVictimFormViewModel.Contactnumber2 = humanVictim.Contactnumber2;
                humanVictimFormViewModel.Dateofbirth = humanVictim.Dateofbirth;
                humanVictimFormViewModel.BiteType = humanVictim.BiteType;
                humanVictimFormViewModel.BiteTypeNonBite = humanVictim.BiteTypeNonBite;
                humanVictimFormViewModel.MedicalTreatmentProvider = humanVictim.MedicalTreatmentProvider;
                humanVictimFormViewModel.RecordCreated = humanVictim.RecordCreated;
                humanVictimFormViewModel.RecordEdited = humanVictim.RecordEdited;
                humanVictimFormViewModel.EmployeeCreated = humanVictim.EmployeeCreatedId;
                humanVictimFormViewModel.EmployeeEdited = humanVictim.EmployeeEditedId;
            }

            humanVictimFormViewModel.Counties = _countyRepository.GetCountiesByStateId(humanVictimFormViewModel.StateId);
            humanVictimFormViewModel.Cities =  _citiesRepository.GetCitiesByState(humanVictimFormViewModel.StateId);


            return View(humanVictimFormViewModel);
        }

        // POST: HumanVictims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Save(HumanVictim humanVictim)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (humanVictim.Id == null)
        //        {
        //            await _humanVictimRepository.Insert(humanVictim);
        //        }
        //        else
        //        {
        //            await _humanVictimRepository.Update(humanVictim);
        //        }

        //        await _humanVictimRepository.SaveChangesAsync();
        //        return RedirectToAction("Details", "Bites", new { biteId = humanVictim.BiteId,Message = Constant.ManageMessageId.SaveHumanVictimDataSuccess});
        //    }

        //    //var humanVicitmViewModel = new HumanVictimViewModel
        //    //{
        //    //    HumanVictim = humanVictim,
        //    //    States = _statesRepository.All(),
        //    //    Counties = _countyRepository.All(),
        //    //    Cities = _citiesRepository.All()
        //    //};

        //    return View("HumanVictimForm", humanVicitmViewModel);
        //}

        // GET: HumanVictims/Delete/5
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
            return View(humanVictim);
        }

        // POST: HumanVictims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string victimId)
        {
            HumanVictim humanVictim = await _humanVictimRepository.GetById(victimId);
            var biteId = humanVictim.BiteId;
            await _humanVictimRepository.DeleteAsync(humanVictim.Id);
            await _humanVictimRepository.SaveChangesAsync();
            return RedirectToAction("Details","Bites",new { biteId = biteId });
        }

    }
}
