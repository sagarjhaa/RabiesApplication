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
            return base.All().Where(b => b.Active.Equals(Constant.Active)).Include("City").Include("State").Include("BiteStatus");
        }

    }
}
