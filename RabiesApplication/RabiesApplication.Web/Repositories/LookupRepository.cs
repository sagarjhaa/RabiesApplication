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
    public class StatesRepository :ActiveRepository<State>
    {
        public override IQueryable<State> All()
        {
            return base.All().Where(s => s.Active == Constant.Active);
        }
    }

    public class CountiesRepository : ActiveRepository<County>
    {
        public override IQueryable<County> All()
        {
            return base.All().Where(s => s.Active == Constant.Active);
        }
    }

    public class CitiesRepository : ActiveRepository<City>
    {
        
        public override IQueryable<City> All()
        {
            return base.All().Where(c => c.Active == Constant.Active);
        }
    }

    public class BiteStatusRepository : ActiveRepository<BiteStatus>
    {
        public override IQueryable<BiteStatus> All()
        {
            return base.All().Where(c => c.Active == Constant.Active);
        }
    }

    public class BreedRepository : ActiveRepository<Breed>
    {
        public override IQueryable<Breed> All()
        {
            return base.All().Where(b => b.Active.Equals(Constant.Active)).OrderBy(b => b.Description);
        }
    }

    public class SpeciesRepository : ActiveRepository<Species>
    {
        public override IQueryable<Species> All()
        {
            return base.All().Where(s => s.Active.Equals(Constant.Active)).OrderBy(s => s.Description);
        }
    }

}
