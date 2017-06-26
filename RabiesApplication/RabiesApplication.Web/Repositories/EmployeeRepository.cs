using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{
    public class EmployeeRepository : AuditRepository<Employee>
    {
        public override IQueryable<Employee> All()
        {
            return base.All().Where(e => e.Active == Constant.Active);
        }
    }
}
