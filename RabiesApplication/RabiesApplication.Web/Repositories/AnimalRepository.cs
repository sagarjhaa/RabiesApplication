using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Repositories
{
    public class AnimalRepository : AuditRepository<Animal>
    {
        public override Task<Animal> GetById(string animalId)
        {
            return Context.Animals.Include("Bites").FirstOrDefaultAsync(a => a.Id.Equals(animalId));
        }

        public AnimalViewModel GetAnimalByBiteId(string biteId,string animalId)
        {
            if (biteId == null)
            {
                return null;
            }
            if (animalId == null)
            {
                var bite = Context.Bites.Include("Animals").First(b => b.Id.Equals(biteId));
                if (bite != null && bite.Animals.Count > 0)
                {
                    var animalWithNoId = bite.Animals.First();
                    return new AnimalViewModel()
                    {
                        Id = animalWithNoId.Id,
                        BiteId = biteId,
                        Name = animalWithNoId.Name,
                        Breed = animalWithNoId.Breed == null ? string.Empty : animalWithNoId.Breed.Description,
                        Species = animalWithNoId.Species.Description,
                        OwnerId = animalWithNoId.AnimalOwnerId
                    };
                }


                //Context.Animals.Include("Breed").Include("Species").Where(animal => animal.Bites.All(bite => bite.Id.Equals(biteId))).FirstOrDefault(aa => aa.Id.Equals(animalId));
                return null;
            }

            var a =  Context.Animals.Include("Breed").Include("Species").FirstOrDefault(aa => aa.Id.Equals(animalId));
            if (a == null)
                return null;
            
            return new AnimalViewModel()
            {
                Id = a.Id,
                BiteId = biteId,
                Name = a.Name,
                Breed = a.Breed == null ? string.Empty : a.Breed.Description,
                Species = a.Species.Description,
                OwnerId = a.AnimalOwnerId
            };
        }

        public List<object> GetAnimalIds()
        {
            List<object> animalIds = (from a in Context.Animals
                                      join ao in Context.AnimalOwner on a.AnimalOwnerId equals  ao.Id
                                      orderby a.Name
                                      select new
                                      {
                                          Id = a.Id,
                                          Name = a.Name + " - " + ao.LastName + " "  + ao.FirstName
                                      }).AsEnumerable<object>().ToList();

            return animalIds;
        }

        public AnimalViewModel GetAnimalData(string animalId)
        {
            var a = Context.Animals.Include("Breed").Include("Species").FirstOrDefault(aa => aa.Id.Equals(animalId));
            if (a == null)
                return null;

            return new AnimalViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Breed = a.Breed == null ? string.Empty : a.Breed.Description,
                Species = a.Species.Description,
                OwnerId = a.AnimalOwnerId
            };
        }

        //public IQueryable<Animal> GetAllPetVictims(string biteId)
        //{
        //    return All().Where(p => p.IsVictim.Equals(Constant.Active)).Where(p => p.BiteId.Equals(biteId)).Include("Breed").Include("Species");
        //}

        //public override Task DeleteAsync(string animalId)
        //{
        //    //Check for petOwner if there is any for the animalId.
        //    //Only animals with isVictim false might have the petOwner information.

        //    var animal = base.GetById(animalId).Result;

        //    //False means it the animal and not pet
        //    if (!animal.IsVictim)
        //    {
        //        //find if there is any animal owner information for this animal. Delete it first if any
        //        var owner =new PetOwner();//Context.PetOwners.FirstOrDefault(o => o.AnimalId.Equals(animal.Id));
        //        if (owner != null) Context.PetOwners.Remove(owner);
        //    }
        //    return base.DeleteAsync(animalId);
        //}
    }
}
