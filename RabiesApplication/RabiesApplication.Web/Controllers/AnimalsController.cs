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
using RabiesApplication.Web.Models;
using RabiesApplication.Web.Repositories;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AnimalRepository _animalRepository = new AnimalRepository();
        private readonly BreedRepository _breedRepository = new BreedRepository();
        private readonly SpeciesRepository _speciesRepository = new SpeciesRepository();
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();
        private readonly VetRepository _vetRepository = new VetRepository();

        // GET: Animal/AnimalForm
        public ActionResult AnimalForm(string biteId, string animalId)
        {
            var animalFormViewModel = new AnimalFormViewModel()
            {
                BiteId = biteId,
                Breed = _breedRepository.All(),
                Species = _speciesRepository.All(),
                Vet = _vetRepository.All()
            };

            if (animalId != null)
            {
                var animalDb = _animalRepository.GetById(animalId).Result;

                animalFormViewModel.Id = animalDb.Id;
                animalFormViewModel.AnimalOwnerId = animalDb.AnimalOwnerId;
                animalFormViewModel.Name = animalDb.Name;
                animalFormViewModel.SpeciesId = animalDb.SpeciesId;
                animalFormViewModel.BreedId = animalDb.BreedId;
                animalFormViewModel.VetId = animalDb.VetId;
                animalFormViewModel.Sex = animalDb.Sex;
                animalFormViewModel.IsVacinated = animalDb.IsVacinated;
                animalFormViewModel.VaccineDate = animalDb.VaccineDate;
                animalFormViewModel.VaccineExpirationDate = animalDb.VaccineExpirationDate;
                animalFormViewModel.TagNumber = animalDb.TagNumber;
                animalFormViewModel.IsVacinatedPost = animalDb.IsVacinatedPost;
                animalFormViewModel.IsVacinatedPrior = animalDb.IsVacinatedPrior;
                animalFormViewModel.IsQuarantine = animalDb.IsQuarantine;
                animalFormViewModel.IsQuarantineCompleted = animalDb.IsQuarantineCompleted;
                animalFormViewModel.QuarantineVerification = animalDb.QuarantineVerification;
                animalFormViewModel.RecordCreated = animalDb.RecordCreated;
                animalFormViewModel.RecordEdited = animalDb.RecordEdited;
                animalFormViewModel.EmployeeCreatedId = animalDb.EmployeeCreatedId;
                animalFormViewModel.EmployeeEditedId = animalDb.EmployeeEditedId;
            }


            return View(animalFormViewModel);
        }


        //// POST: Animals/SaveAnimal
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SaveAnimal(Animal animal)
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
        //        return RedirectToAction("Details", "Bites", new { biteId = animal.BiteId, Message = Constant.ManageMessageId.SavePetVictimDataSuccess });
        //    }

        //    var AnimalFormViewModel = new AnimalViewModel
        //    {
        //        Animal = animal,
        //        Breeds = _breedRepository.All(),
        //        Specieses = _speciesRepository.All(),
        //        Employees = _employeeRepository.All(),
        //        Vets = _vetRepository.All()
        //    };
        //    return View("AnimalForm", AnimalFormViewModel);
        //}


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
