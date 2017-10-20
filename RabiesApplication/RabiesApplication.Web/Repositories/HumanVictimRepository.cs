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
                join s in Context.States on h.StateId equals s.Id
                join c in Context.Cities on h.CityId equals c.Id
                select new HumanVictimViewModel()
                {
                    City = c.CityName,
                    FirstName = h.FirstName,
                    Id = h.Id,
                    LastName = h.LastName,
                    State = s.StateName,
                    Zip = h.Zipcode.ToString()
                }).ToList();

            return h1;
        }

    }
}
