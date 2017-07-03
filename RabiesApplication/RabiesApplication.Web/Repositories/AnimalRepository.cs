using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class AnimalRepository : AuditRepository<Animal>
    {
        public IQueryable<Animal> GetAllPetVictims(string biteId)
        {
            return All().Where(p => p.IsVictim.Equals(Constant.Active)).Where(p => p.BiteId.Equals(biteId)).Include("Breed").Include("Species");
        }

        public Animal GetAnimalByBiteId(string biteId)
        {
            return Context.Animals.Include("Breed").Include("Species").Where(p => p.IsVictim.Equals(Constant.Deactive)).SingleOrDefault(model => model.BiteId.Equals(biteId));
        }

        public override Task DeleteAsync(string animalId)
        {
            //Check for petOwner if there is any for the animalId.
            //Only animals with isVictim false might have the petOwner information.

            var animal = base.GetById(animalId).Result;

            //False means it the animal and not pet
            if (!animal.IsVictim)
            {
                //find if there is any animal owner information for this animal. Delete it first if any
                var owner = Context.PetOwners.FirstOrDefault(o => o.AnimalId.Equals(animal.Id));
                if (owner != null) Context.PetOwners.Remove(owner);
            }
            return base.DeleteAsync(animalId);
        }
    }
}
