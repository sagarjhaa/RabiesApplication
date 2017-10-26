using System;
using System.Collections;
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
    public class BiteRepository : ActiveRepository<Bite>
    {
     
        //public Task BiteDetailsWithAnimal(string biteId)
        //{
        //    var bite =  base.Context.Bites.Where(b => b.Id.Equals(biteId));

        //    var biteWithAnimal = bite.Where(b => b.Animals.Where(a => !a.IsVictim)).ToListAsync();

        //    return biteWithAnimal;
        //}

        public override IQueryable<Bite> All()
        {
            return base.All().Where(b => b.Active.Equals(Constant.Active)).Include("City").Include("State").Include("BiteStatus").OrderByDescending(b => b.BiteDate);
        }

        public BiteJustViewModel GetBiteJustViewModel(string biteId)
        {
            var b =
                Context.Bites
                    .Include("City")
                    .Include("State")
                    .Include("BiteStatus")
                    .FirstOrDefault(bite => bite.Id.Equals(biteId));


            return new BiteJustViewModel()
            {
                Id = b.Id,
                City = b.City.CityName,
                Status = b.BiteStatus.Description,
                BiteDate = b.BiteDate.Value,
                ReportDate = b.BiteReportDate.Value,
                Comments = b.Comments
            };
        }

        public IEnumerable<BitesViewModel> GetBiteIndexView()
        {
            var bites = (from bite in Context.Bites

                         join city in Context.Cities on bite.CityId equals city.Id into cities
                         from c in cities.DefaultIfEmpty()
                         join status in Context.BiteStatuses on bite.BiteStatusId equals status.Id into statuses
                         from s in statuses.DefaultIfEmpty()
                         join victim in Context.HumanVictims on bite.Id equals victim.BiteId into victims
                         from v in victims.DefaultIfEmpty()
                         join owner in Context.AnimalOwner on bite.Animals.FirstOrDefault().AnimalOwnerId equals owner.Id into owners
                         from o in owners.DefaultIfEmpty()
                         where bite.Active.Equals(Constant.Active)
                         select new BitesViewModel
                         {
                             Id = bite.Id,
                             AnimalOwnerId = o.Id,
                             AnimalOwner = o.FirstName + " " + o.LastName,
                             AnimalId = bite.Animals.FirstOrDefault().Id,
                             AnimalName = bite.Animals.FirstOrDefault().Name,
                             BiteDate = bite.BiteDate,
                             City = c.CityName,
                             Status = s.Description,
                             VictimId = v.Id,
                             VictimName = v.FirstName + " " + v.LastName,
                             RecordCreated = bite.RecordCreated
                         });

            return bites.ToList().OrderByDescending(b => b.RecordCreated);

        }

    }
}
