using System.Collections.Generic;
using System.Linq;
using RabiesApplication.Models;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Repositories
{
    public class AnimalOwnerRepository : AuditRepository<AnimalOwner>
    {
        public Dictionary<string, string> GetAnimalOwners()
        {
            return  Context.AnimalOwner
                .OrderBy(ao => ao.LastName)
                .Select(ao => new {ao.Id, Name = ao.LastName + " " + ao.FirstName})
                .ToDictionary(ao => ao.Id, ao => ao.Name);
        }

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
    }
}