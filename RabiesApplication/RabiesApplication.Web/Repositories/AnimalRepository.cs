using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class AnimalRepository : AuditRepository<Animal>
    {
        public IQueryable<Animal> GetAllPetVictims(string biteId)
        {
            return All().Where(p => p.IsVictim.Equals(Constant.Active)).Where(p => p.BiteId.Equals(biteId));
        }
    }
}
