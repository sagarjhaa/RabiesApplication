using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{

    public abstract class AuditRepository<TEntity> : ModelRepository<TEntity>
        where TEntity : class, IModel, IAuditable
    {
        public override Task Insert(TEntity model)
        {
            var user = new UserRepository().GetUserID(System.Web.HttpContext.Current.User);
            if (model.Id == null || (DateTimeOffset.Compare(default(DateTimeOffset), model.RecordCreated).Equals(0)))
            {
                model.RecordCreated = DateTimeOffset.Now;
                model.EmployeeCreatedId = user;
            }
            return base.Insert(model);
        }

        public override Task Update(TEntity model)
        {
            var user = new UserRepository().GetUserID(System.Web.HttpContext.Current.User);
            model.RecordEdited = DateTimeOffset.Now;
            model.EmployeeEditedId = user;
            return base.Update(model);
        }

        //public override Task InsertOrUpdateAsync(TEntity model)
        //{
        //    // ensure organization is set on model
        //    var user = new UserRepository().GetUserID(System.Web.HttpContext.Current.User);
        //    if (model.Id == null)
        //    {
        //        model.RecordCreated = DateTimeOffset.Now;
        //        model.EmployeeCreatedId = user;
        //    }
        //    else
        //    {
        //        model.RecordEdited = DateTimeOffset.Now;
        //        model.EmployeeEditedId = user;
        //    }
        //    return base.InsertOrUpdateAsync(model);
        //}
    }
}
