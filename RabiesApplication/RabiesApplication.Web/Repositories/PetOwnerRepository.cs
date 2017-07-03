using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;

namespace RabiesApplication.Web.Repositories
{
    public class PetOwnerRepository : AuditRepository<PetOwner>
    {
        public PetOwner GetOwnerByAnimalId(string animalId)
        {
            return Context.PetOwners.FirstOrDefault(model => model.AnimalId.Equals(animalId));
        }

        public PetOwner GetOwnerByBiteId(string biteId)
        {
            var animal = Context.Animals.Where(a => a.BiteId.Equals(biteId)).ToList();
            var animalId = animal[0].Id;
            return Context.PetOwners.FirstOrDefault(o => o.AnimalId.Equals(animalId));
        }
    }
}
