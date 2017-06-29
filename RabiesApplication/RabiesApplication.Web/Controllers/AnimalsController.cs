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
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class AnimalsController : Controller
    {
        private DataContext db = new DataContext();
        private readonly AnimalRepository _animalRepository = new AnimalRepository();
        private readonly BreedRepository _breedRepository = new BreedRepository();
        private readonly SpeciesRepository _speciesRepository = new SpeciesRepository();
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly VetRepository _vetRepository = new VetRepository();

        // GET: Animals/Create
        public ActionResult PetForm(string biteId,string petid)
        {
            var PetFormViewModel = new AnimalViewModel
            {
                Animal = new Animal(biteId),
                Breeds = _breedRepository.All(),
                Specieses = _speciesRepository.All(),
                Employees = _employeeRepository.All(),
                Vets = _vetRepository.All()
            };

            if (petid != null)
            {
                PetFormViewModel.Animal =  _animalRepository.GetById(petid).Result;
            }


            return View(PetFormViewModel);
        }

        // POST: Animals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save( Animal animal)
        {
            if (ModelState.IsValid)
            {
                await _animalRepository.InsertOrUpdateAsync(animal);
                await _animalRepository.SaveChangesAsync();
                return RedirectToAction("Details","Bites",new {id = animal.BiteId});
            }

            var PetFormViewModel = new AnimalViewModel
            {
                Animal = animal,
                Breeds = _breedRepository.All(),
                Specieses = _speciesRepository.All(),
                Employees = _employeeRepository.All(),
                Vets = _vetRepository.All()
            };
            return View("PetForm",animal);
        }

       
        // GET: Animals/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Animal animal = await db.Animals.FindAsync(id);
            db.Animals.Remove(animal);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

      
    }
}
