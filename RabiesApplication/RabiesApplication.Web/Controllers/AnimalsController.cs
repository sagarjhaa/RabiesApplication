using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Helpers;
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
        private readonly VetRepository _vetRepository = new VetRepository();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveAnimal(AnimalFormViewModel animalFormViewModel)
        {
            if (ModelState.IsValid)
            {
                var animal = Mapper.Map<AnimalFormViewModel, Animal>(animalFormViewModel);

                //Get the animals with the bites
                //loop through each bite and check if this animal is realted to the current biteId
                //if then

                var animalDb = _animalRepository.GetById(animal.Id).Result;
                
                var currentBite = _animalRepository.Context.Bites.Find(animalFormViewModel.BiteId);//_biteRepository.GetById(animalFormViewModel.BiteId).Result;
                if (animalDb == null)
                {
                    animal.Bites.Add(currentBite);
                }
                else
                {
                    if (!animalDb.Bites.Contains(currentBite))
                    {
                        animal.Bites.Add(currentBite);
                    }
                    else
                    {
                        animal.Bites = null;
                    }
                }

                if (animal.Id == null)
                {
                    await _animalRepository.Insert(animal);
                }
                else
                {
                    //Detach the last animalDb in order to add the current data.
                    _animalRepository.Context.Entry(animalDb).State = EntityState.Detached;
                    await _animalRepository.Update(animal);
                }
                await _animalRepository.SaveChangesAsync();
                return RedirectToAction("Details", "Bites", new { biteId = animalFormViewModel.BiteId, animalId=animalFormViewModel.Id, Message = Constant.ManageMessageId.SavePetVictimDataSuccess });
            }

            animalFormViewModel.AnimalOwner = _animalOwnerRepository.GetAnimalOwners();
            animalFormViewModel.Breed = _breedRepository.All();
            animalFormViewModel.Species = _speciesRepository.All();
            animalFormViewModel.Vet = _vetRepository.All();


            return View("AnimalForm", animalFormViewModel);
        }

        [HttpGet]
        public ActionResult SelectAnimal(string biteId)
        {
            ViewBag.BiteId = biteId;
            var animalListViewModel = new AnimalListViewModel()
            {
                BiteId = biteId
            };
            return View(animalListViewModel);
        }

        [HttpPost]
        public ActionResult Link(AnimalListViewModel animalvm)
        {
            var animalId = animalvm.AnimalId;//Request["selectedAnimalId"];
            var biteId = animalvm.BiteId;//Request[" BiteId"];
  

            var animal = _animalRepository.GetById(animalId).Result;
            var addToBite = _animalRepository.Context.Bites.Find(biteId);
            animal.Bites.Add(addToBite);
             _animalRepository.Update(animal);
             _animalRepository.SaveChangesAsync();
            return RedirectToAction("Details", "Bites", new { biteId = biteId,animalId = animalId, Message = Constant.ManageMessageId.SavePetVictimDataSuccess });
        }

        [HttpPost]
        public ActionResult Delink(string animalId, string biteId)
        {
            var animal = _animalRepository.GetById(animalId).Result;
            var removeBite = animal.Bites.First(b => b.Id.Equals(biteId));
            animal.Bites.Remove(removeBite);
            _animalRepository.Update(animal);
            _animalRepository.SaveChangesAsync();
            return RedirectToAction("Details", "Bites", new { biteId = biteId, Message = Constant.ManageMessageId.SavePetVictimDataSuccess });
        }

        public JsonResult GetAnimalIdList()
        {
            var Animals = _animalRepository.GetAnimalIds();
            return Json(Animals, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJsonAnimalById(string animalId)
        {
            var animalDb = _animalRepository.GetById(animalId).Result;
            var animalFormViewModel = Mapper.Map<Animal, AnimalFormViewModel>(animalDb);

            var finalResult = new
            {
                OwnerName = animalDb.AnimalOwner != null ? animalDb.AnimalOwner.LastName + " " + animalDb.AnimalOwner.FirstName : null,
                Breed = animalDb.Breed?.Description,
                Species = animalDb.Species?.Description,
                Vet = animalDb.Vet?.FirstName,
                ViewModel = animalFormViewModel
            };

            return Json(finalResult, JsonRequestBehavior.AllowGet);
        }
    }
}
