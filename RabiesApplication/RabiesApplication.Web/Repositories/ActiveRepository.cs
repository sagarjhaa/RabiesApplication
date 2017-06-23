using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{

    public abstract class ActiveRepository<TEntity> : AuditRepository<TEntity>
        where TEntity : class, IModel, IAuditable,IActive
    {

        public override Task InsertOrUpdateAsync(TEntity model)
        {
            if (model.Id == null)
            {
                model.Active = Constant.Active;
            }
            //else
            //{
            //    model.DateEdited = DateTimeOffset.Now;
            //    model.MemberEditedId = user;
            //}
            return base.InsertOrUpdateAsync(model);
        }
    }
}
