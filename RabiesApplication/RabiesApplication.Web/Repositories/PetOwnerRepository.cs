using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class PetOwnerRepository : AuditRepository<PetOwner>
    {
        public PetOwner GetOwnerByAnimalId(string animalId)
        {
            return Context.PetOwners.FirstOrDefault(model => model.AnimalId.Equals(animalId));
        }

        public PetOwner GetAnimalOwnerByBiteId(string biteId)
        {
            var animal = Context.Animals.Where(a => a.BiteId.Equals(biteId)).Where(a => a.IsVictim.Equals(Constant.Deactive)).ToList();
            if (!animal.Any()) return null;
            var animalId = animal[0].Id;
            return Context.PetOwners.Include("State").Include("City").FirstOrDefault(o => o.AnimalId.Equals(animalId));
        }
    }
}
