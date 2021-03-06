﻿using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
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
            var humanVicitmViewModel = new HumanVictimViewModel
            {
                HumanVictim = new HumanVictim(biteId),
                States = _statesRepository.All(),
                Counties = _countyRepository.All(),
                Cities = _citiesRepository.All()
            };

            if (victimId != null)
            {
                humanVicitmViewModel.HumanVictim = _humanVictimRepository.GetById(victimId).Result;
            }

            return View(humanVicitmViewModel);
        }

        // POST: HumanVictims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(HumanVictim humanVictim)
        {
            if (ModelState.IsValid)
            {
                if (humanVictim.Id == null)
                {
                    await _humanVictimRepository.Insert(humanVictim);
                }
                else
                {
                    await _humanVictimRepository.Update(humanVictim);
                }

                await _humanVictimRepository.SaveChangesAsync();
                return RedirectToAction("Details", "Bites", new { biteId = humanVictim.BiteId,Message = Constant.ManageMessageId.SaveHumanVictimDataSuccess});
            }

            var humanVicitmViewModel = new HumanVictimViewModel
            {
                HumanVictim = humanVictim,
                States = _statesRepository.All(),
                Counties = _countyRepository.All(),
                Cities = _citiesRepository.All()
            };

            return View("HumanVictimForm", humanVicitmViewModel);
        }

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
