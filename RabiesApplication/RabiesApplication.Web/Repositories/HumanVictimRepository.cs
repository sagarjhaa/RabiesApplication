using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RabiesApplication.Models;
using RabiesApplication.Web.ViewModels;

namespace RabiesApplication.Web.Repositories
{
    class HumanVictimRepository :AuditRepository<HumanVictim>
    {

        public IEnumerable<HumanVictimViewModel> GetHumanVictimViewModelByBiteId(string biteId)
        {
            
            var h1 = (from h in Context.HumanVictims
                where h.BiteId.Equals(biteId)
                join s in Context.States on h.StateId equals s.Id into humanStates
                from humanState in humanStates.DefaultIfEmpty()
                join c in Context.Cities on h.CityId equals c.Id  into humanCities  
                from humanCity in humanCities.DefaultIfEmpty()
                select new HumanVictimViewModel()
                {
                    City = humanCity.CityName,
                    FirstName = h.FirstName,
                    Id = h.Id,
                    BiteId = h.BiteId,
                    LastName = h.LastName,
                    State = humanState.StateName,
                    Zip = h.Zipcode.ToString()
                });

            return h1.ToList();
        }

    }
}
