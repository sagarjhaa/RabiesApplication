﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabiesApp.Models;
using RabiesApplication.Web;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class HumanVictimsController : Controller
    {
        private DataContext db = new DataContext();

        private HumanVictimRepository _humanVictimRepository = new HumanVictimRepository();
        private StatesRepository _statesRepository = new StatesRepository();
        private CountiesRepository _countyRepository = new CountiesRepository();
        private CitiesRepository _citiesRepository = new CitiesRepository();
       
        

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

            }

            
            return View(humanVicitmViewModel);
        }

        // POST: HumanVictims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RowVersion,BiteId,FirstName,LastName,Dateofbirth,Age,Addressline1,Addressline2,CityId,CountyId,StateId,Zipcode,Contactnumber1,Contactnumber2,BiteType,BiteTypeNonBite,PostExposureProphylaxis,MedicalTreatmentProvider,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] HumanVictim humanVictim)
        {
            if (ModelState.IsValid)
            {
                db.HumanVictims.Add(humanVictim);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BiteId = new SelectList(db.Bites, "Id", "CityId", humanVictim.BiteId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", humanVictim.CityId);
            ViewBag.CountyId = new SelectList(db.Counties, "Id", "Name", humanVictim.CountyId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", humanVictim.StateId);
            return View(humanVictim);
        }

        // GET: HumanVictims/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HumanVictim humanVictim = await db.HumanVictims.FindAsync(id);
            if (humanVictim == null)
            {
                return HttpNotFound();
            }
            return View(humanVictim);
        }

        // POST: HumanVictims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            HumanVictim humanVictim = await db.HumanVictims.FindAsync(id);
            db.HumanVictims.Remove(humanVictim);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
