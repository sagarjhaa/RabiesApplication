using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RabiesApplication.Models;
using RabiesApplication.Web;
using RabiesApplication.Web.Repositories;

namespace RabiesApplication.Web.Controllers
{
    public class VetsController : Controller
    {
        //Todo Work on VetsController to include repository and actions

        private DataContext db = new DataContext();

        private readonly VetRepository _vetRepository = new VetRepository();

        // GET: Vets
        public async Task<ActionResult> Index()
        {
            var vets = _vetRepository.All();
            return View(await vets.ToListAsync());
        }


        // GET: Vets/Create
        public ActionResult VetForm(string vetId)
        {



            if (vetId != null)
            {
                
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName");
            return View();
        }

        // POST: Vets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RowVersion,FirstName,LastName,Dateofbirth,Age,Addressline1,Addressline2,CityId,CountyId,StateId,Zipcode,Contactnumber1,Contactnumber2,Comments,Active,RecordCreated,RecordEdited,EmployeeCreatedId,EmployeeEditedId")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Vets.Add(vet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", vet.CityId);
            ViewBag.StateId = new SelectList(db.States, "Id", "StateName", vet.StateId);
            return View(vet);
        }

       
        // GET: Vets/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = await db.Vets.FindAsync(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Vet vet = await db.Vets.FindAsync(id);
            db.Vets.Remove(vet);
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
