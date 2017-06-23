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

        public override Task InsertOrUpdateAsync(TEntity model)
        {
            // ensure organization is set on model
            var user = new UserRepository().GetUserID(System.Web.HttpContext.Current.User);
            if (model.Id == null)
            {
                model.DateCreated = DateTimeOffset.Now;
                model.MemberCreatedId = user;
            }
            else
            {
                model.DateEdited = DateTimeOffset.Now;
                model.MemberEditedId = user;
            }
            return base.InsertOrUpdateAsync(model);
        }
    }
}
