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
using RabiesApplication.Web.Repositories;

namespace RabiesApplication.Web.Controllers
{
    public class BitesController : Controller
    {
        private DataContext db = new DataContext();
        private readonly BiteRepository biteRepository = new BiteRepository();
        private readonly StatesRepository _statesRepository = new StatesRepository();
        private readonly CitiesRepository _citiesRepository = new CitiesRepository();
        private readonly EmployeeRepository _employee = new EmployeeRepository();

        // GET: Bites
        public ActionResult Index()
        {
            var bites = db.Bites.Include(b => b.BiteStatus).Include(b => b.City).Include(b => b.State);
            return View(bites.ToList());
        }

        // GET: Bites/Details/5
        public ActionResult Details(string id)
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

        // GET: Bites/Create
        public async Task<ActionResult> BiteForm(int? id)
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
                await biteRepository.InsertOrUpdateAsync(bite);
                await biteRepository.SaveChangesAsync();
                return View("Index");
                //return RedirectToAction("Create", "HumanVictims", new { id = bite.Id });
            }

            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description", bite.BiteStatusId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", bite.CityId);
            ViewBag.EmployeeAssignedId = new SelectList(db.Users, "Id", "Email", bite.EmployeeAssignedId);
            ViewBag.EmployeecreatedId = new SelectList(db.Users, "Id", "Email", bite.EmployeeCreatedId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", bite.StateId);
            return View("BiteForm", bite);
        }


        // GET: Bites/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description", bite.BiteStatusId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", bite.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", bite.StateId);
            return View(bite);
        }

        // POST: Bites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RowVersion,CityId,StateId,BiteDate,BiteReportDate,BiteReportedBy,BiteStatusId,Comments,EmployeeAssignedId,Active,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] Bite bite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BiteStatusId = new SelectList(db.BiteStatuses, "Id", "Description", bite.BiteStatusId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", bite.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", bite.StateId);
            return View(bite);
        }

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
            Bite bite = db.Bites.Find(id);
            db.Bites.Remove(bite);
            db.SaveChanges();
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
