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

namespace RabiesApplication.Web.Controllers
{
    public class BitesController : Controller
    {
        private DataContext db = new DataContext();
        private readonly BiteRepository _biteRepository = new BiteRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();
        private readonly EmployeeRepository _employee = new EmployeeRepository();
        private readonly BiteStatus _biteStatus = new BiteStatus();

        // GET: Bites
        public ActionResult Index()
        {
            var bites = _biteRepository.All();
            return View(bites.ToList());
        }

        public async Task<ActionResult> BiteForm(string id)
        {
            ViewBag.StateId = new SelectList(_statesRepository.All(), "Id", "StateName");
            ViewBag.CityId = new SelectList(_citiesRepository.All(), "Id", "CityName");
            ViewBag.Employee = new SelectList(_employee.All(), "Id", "FirstName");
            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description");


            var bite = new Bite();

            if (id != null)
            {
                bite = await db.Bites.FindAsync(id);
                if (bite == null)
                {
                    return HttpNotFound();
                }
            }

            return View(bite);
        }


        // POST: Bites/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(Bite bite)
        {
            //Remove checking on EmployeecreatedId
            ModelState.Remove("EmployeecreatedId");


            if (ModelState.IsValid)
            {
                await _biteRepository.InsertOrUpdateAsync(bite);
                await _biteRepository.SaveChangesAsync();
                return RedirectToAction("Index");
                //return RedirectToAction("Create", "HumanVictims", new { id = bite.Id });
            }

            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description", bite.BiteStatusId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", bite.CityId);
            ViewBag.EmployeeAssignedId = new SelectList(db.Users, "Id", "Email", bite.EmployeeAssignedId);
            ViewBag.EmployeecreatedId = new SelectList(db.Users, "Id", "Email", bite.EmployeeCreatedId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", bite.StateId);
            return View("BiteForm", bite);
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


        // GET: Bites/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bite bite = db.Bites.Find(id);
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
