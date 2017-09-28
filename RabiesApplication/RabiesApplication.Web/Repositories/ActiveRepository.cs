using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Models.Interfaces;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{

    public abstract class ActiveRepository<TEntity> : AuditRepository<TEntity>
        where TEntity : class, IModel,IActive,IAuditable
    {
        public override Task Insert(TEntity model)
        {
            if (model.Id == null)
            {
                model.Active = Constant.Active;
            }
            return base.Insert(model);
        }

        public override Task Update(TEntity model)
        {
            return base.Update(model);
        }

        //public override Task InsertOrUpdateAsync(TEntity model)
        //{
        //    if (model.Id == null)
        //    {
        //        model.Active = Constant.Active;
        //    }
        //    return base.InsertOrUpdateAsync(model);
        //}
    }
}
