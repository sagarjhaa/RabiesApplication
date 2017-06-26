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

    public class CitiesRepository : ActiveRepository<City>
    {
        
        public override IQueryable<City> All()
        {
            return base.All().Where(c => c.Active == Constant.Active);
        }
    }


}
