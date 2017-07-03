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

        public IQueryable<Animal> GetAllAnimals(string biteId)
        {
            return All().Where(p => p.IsVictim.Equals(Constant.Deactive)).Where(p => p.BiteId.Equals(biteId)).Include("Breed").Include("Species");
        }

        public IQueryable<Animal> GetAnimalByBiteId(string biteId)
        {
            return All().Where(p => p.IsVictim.Equals(Constant.Deactive)).Where(p => p.BiteId.Equals(biteId)).Include("Breed").Include("Species").Take(1);
        }

        public Animal GetByBiteId(string biteId)
        {
            return Context.Animals.Include("Breed").Include("Species").SingleOrDefault(model => model.BiteId.Equals(biteId));
        }
    }
}
