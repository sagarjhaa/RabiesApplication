using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RabiesApplication.Models;

namespace RabiesApplication.Web.Repositories
{
    class HumanVictimRepository :AuditRepository<HumanVictim>
    {

        public IEnumerable<HumanVictim> GetAllByBiteId(string biteId)
        {
            return base.All().Where(v => v.BiteId == biteId).Include("State").Include("City").Include("County");
        }

    }
}
