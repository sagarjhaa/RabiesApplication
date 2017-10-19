using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class BiteRepository : ActiveRepository<Bite>
    {
        public override Task Insert(Bite model)
        {
            model.BiteStatusId = BiteStatusConstant.New;
            return base.Insert(model);
        }

        //public Task BiteDetailsWithAnimal(string biteId)
        //{
        //    var bite =  base.Context.Bites.Where(b => b.Id.Equals(biteId));

        //    var biteWithAnimal = bite.Where(b => b.Animals.Where(a => !a.IsVictim)).ToListAsync();

        //    return biteWithAnimal;
        //}

        public override IQueryable<Bite> All()
        {
            return base.All().Where(b => b.Active.Equals(Constant.Active)).Include("City").Include("State").Include("BiteStatus").Include("HumanVictims").OrderByDescending(b => b.BiteDate);
        }

        //public IEnumerable<BitesViewModel> GetBiteIndexView()
        //{
        //    //var bites =  (from bite in Context.Bites
        //    //                    join city in Context.Cities on bite.CityId equals city.Id into cities
        //    //                    from c in cities.DefaultIfEmpty()
        //    //                    join status in Context.BiteStatuses on bite.BiteStatusId equals status.Id into statuses
        //    //                    from s in statuses.DefaultIfEmpty()
        //    //                    join victim in Context.HumanVictims on bite.Id equals victim.BiteId into victims
        //    //                    from v in victims.DefaultIfEmpty()
        //    //                    join animal in Context.Animals on bite.Id equals animal.BiteId into animals
        //    //                    from a in animals.DefaultIfEmpty()
        //    //                    join owner in Context.PetOwners on a.Id equals owner.Id into owners
        //    //                    from o in owners.DefaultIfEmpty()
        //    //                    where bite.Active.Equals(Constant.Active)
        //    //                                select new BitesViewModel
        //    //                                {
        //    //                                    Id = bite.Id,
        //    //                                    PetOwner = o.FirstName + " " + o.LastName,
        //    //                                    AnimalName = a.Name,
        //    //                                    BiteDate = bite.BiteDate,
        //    //                                    City = c.CityName,
        //    //                                    //Status = statuses.,
        //    //                                    VictimName = v.FirstName + " " + v.LastName
        //    //                                });

        //    var bites = Context.Bites.

        //    return bites.ToList();

        //}

    }
}
