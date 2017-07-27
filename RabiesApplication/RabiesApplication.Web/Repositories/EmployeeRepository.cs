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

        public override Task Insert(Employee model)
        {
            model.OrganizationId = Constant.OrganizationCcbh;
            return base.Insert(model);
        }

        public override Task Update(Employee model)
        {
            return base.Update(model);
        }

        //public override Task InsertOrUpdateAsync(Employee model)
        //{
        //    model.OrganizationId = Constant.OrganizationCcbh;
        //    return base.InsertOrUpdateAsync(model);
        //}
    }
}
