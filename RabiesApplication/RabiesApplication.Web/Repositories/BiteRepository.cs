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
        public override Task InsertOrUpdateAsync(Bite model)
        {
            if (model.Id == null)
            {
                model.BiteStatusId = BiteStatusConstant.New;
            }

            return base.InsertOrUpdateAsync(model);
        }

        public override IQueryable<Bite> All()
        {
            return base.All().Where(b => b.Active.Equals(Constant.Active)).Include("City").Include("State").Include("BiteStatus");
        }
    }
}
