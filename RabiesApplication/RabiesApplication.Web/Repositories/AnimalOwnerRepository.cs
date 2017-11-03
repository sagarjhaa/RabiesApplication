using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RabiesApplication.Models;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Repositories
{
    public class AnimalOwnerRepository : AuditRepository<AnimalOwner>
    {
        //Get the List of AnimalOwner for the index page.
        public List<AnimalOwner> All()
        {
            return Context.AnimalOwner.OrderBy(a => a.FirstName).ToList();
        }

        //Get list of AnimalOwners Names for the Animals Page.
        public Dictionary<string, string> GetAnimalOwners()
        {
            return  Context.AnimalOwner
                .OrderBy(ao => ao.LastName)
                .Select(ao => new {ao.Id, Name = ao.LastName + " " + ao.FirstName})
                .ToDictionary(ao => ao.Id, ao => ao.Name);
        }

        //Get AnimalOwner view to be shown on the details page.
        public AnimalOwnerViewModel GetOwnerByAnimalId(string animalOwnerId)
        {
            var owner = (from o in Context.AnimalOwner
                    where o.Id.Equals(animalOwnerId)
                    join s in Context.States on o.StateId equals s.Id into states
                    from state in states.DefaultIfEmpty()
                    join c in Context.Cities on o.CityId equals c.Id into cities
                    from city in cities.DefaultIfEmpty()
                    select new AnimalOwnerViewModel()
                    {
                        FirstName = o.FirstName,
                        LastName = o.LastName,
                        Id = o.Id,
                        Zip = o.Zipcode.ToString(),
                        State = state.StateName,
                        City = city.CityName
                    });


            return owner.FirstOrDefault();
        }

        //Get the animals for the AnimalOwner details page.
        public IEnumerable<AnimalListByOwner> GetAnimalsByOwnerId(string animalOwnerId)
        {
            if (animalOwnerId == null)
            {
                return  (from a in Context.Animals
                           select new AnimalListByOwner()
                           {
                               Name =  a.Name,
                               Breed = a.Breed.Description,
                               Species = a.Species.Description,
                               BiteCount = a.Bites.Count
                           }).Include("Bites").OrderByDescending(a => a.BiteCount).ToList();
            }

            return (from a in Context.Animals
                    where a.AnimalOwnerId.Equals(animalOwnerId)
                    select new AnimalListByOwner()
                    {
                        Name = a.Name,
                        Breed = a.Breed.Description,
                        Species = a.Species.Description,
                        BiteCount = a.Bites.Count
                    }).OrderByDescending(a => a.BiteCount).ToList();
        }
    }
}