using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RabiesApplication.Models;
using RabiesApplication.Web;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AnimalRepository _animalRepository = new AnimalRepository();
        private readonly AnimalOwnerRepository _animalOwnerRepository = new AnimalOwnerRepository();
        private readonly BreedRepository _breedRepository = new BreedRepository();
        private readonly SpeciesRepository _speciesRepository = new SpeciesRepository();
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly VetRepository _vetRepository = new VetRepository();

        // GET: Animal/AnimalForm
        public ActionResult AnimalForm(string biteId, string animalId)
        {
            if (biteId == null)
            {
                return HttpNotFound("Plese provide proper data");
            }

            if (animalId == null)
            {
                var animalFormViewModel = new AnimalFormViewModel()
                {
                    BiteId = biteId,
                    AnimalOwner = _animalOwnerRepository.GetAnimalOwners(),
                    Breed = _breedRepository.All(),
                    Species = _speciesRepository.All(),
                    Vet = _vetRepository.All()
                };

                return View(animalFormViewModel);
            }

            
            var animalDb = _animalRepository.GetById(animalId).Result;

            if (animalDb != null)
            {

                var animalFormViewModel = Mapper.Map<Animal, AnimalFormViewModel>(animalDb);
                animalFormViewModel.AnimalOwner = _animalOwnerRepository.GetAnimalOwners();
                animalFormViewModel.Breed = _breedRepository.All();
                animalFormViewModel.Species = _speciesRepository.All();
                animalFormViewModel.Vet = _vetRepository.All();

                return View(animalFormViewModel);
            }
            return HttpNotFound("Animal is not found");

            
        }


        // POST: Animals/SaveAnimal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveAnimal(AnimalFormViewModel animalFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var animal = Mapper.Map<AnimalFormViewModel, Animal>(animalFormViewModel);

                if (animal.Id.Equals(null))
                {
                    await _animalRepository.Insert(animal);
                }
                else
                {
                    await _animalRepository.Update(animal);
                }
                await _animalRepository.SaveChangesAsync();
                return RedirectToAction("Details", "Bites", new { biteId = animal, Message = Constant.ManageMessageId.SavePetVictimDataSuccess });
            }

            var AnimalFormViewModel = new AnimalViewModel
            {
                Animal = animal,
                Breeds = _breedRepository.All(),
                Specieses = _speciesRepository.All(),
                Employees = _employeeRepository.All(),
                Vets = _vetRepository.All()
            };
            return View("AnimalForm", AnimalFormViewModel);
        }


        //// GET: Animals/Delete/5
        //public async Task<ActionResult> Delete(string animalId)
        //{
        //    if (animalId == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Animal animal = await _animalRepository.GetById(animalId);
        //    if (animal == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(animal);
        //}

        //// POST: Animals/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string animalId)
        //{
        //    var animal = _animalRepository.GetById(animalId).Result;
        //    var biteId = animal.BiteId;

        //    await _animalRepository.DeleteAsync(animalId);
        //    await _animalRepository.SaveChangesAsync();

        //    return RedirectToAction("Details", "Bites", new { biteId = biteId, Message = Constant.ManageMessageId.DeletePetVictimSuccess });
        //}


































        //// GET: Animals/PetForm
        //public ActionResult PetForm(string biteId,string petId)
        //{
        //    var PetFormViewModel = new AnimalViewModel
        //    {
        //        Animal = new Animal(biteId),
        //        Breeds = _breedRepository.All(),
        //        Specieses = _speciesRepository.All(),
        //        Employees = _employeeRepository.All(),
        //        Vets = _vetRepository.All()
        //    };

        //    if (petId != null)
        //    {
        //        PetFormViewModel.Animal =  _animalRepository.GetById(petId).Result;
        //    }


        //    return View(PetFormViewModel);
        //}



        //// POST: Animals/SavePet
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SavePet( Animal animal)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (animal.Id.Equals(null))
        //        {
        //            await _animalRepository.Insert(animal);
        //        }
        //        else
        //        {
        //            await _animalRepository.Update(animal);
        //        }

        //        await _animalRepository.SaveChangesAsync();
        //        return RedirectToAction("Details","Bites",new {biteId = animal.BiteId, Message = Constant.ManageMessageId.SavePetVictimDataSuccess });
        //    }

        //    var PetFormViewModel = new AnimalViewModel
        //    {
        //        Animal = animal,
        //        Breeds = _breedRepository.All(),
        //        Specieses = _speciesRepository.All(),
        //        Employees = _employeeRepository.All(),
        //        Vets = _vetRepository.All()
        //    };
        //    return View("PetForm", PetFormViewModel);
        //}





    }
}
