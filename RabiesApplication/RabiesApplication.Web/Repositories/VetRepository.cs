using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class VetRepository: ActiveRepository<Vet>
    {
        public override IQueryable<Vet> All()
        {
            return base.All().Where(v => v.Active.Equals(Constant.Active));
        }
    }
}
