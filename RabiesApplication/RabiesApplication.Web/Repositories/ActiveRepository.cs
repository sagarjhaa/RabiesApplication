using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{

    public abstract class ActiveRepository<TEntity> : ModelRepository<TEntity>
        where TEntity : class, IModel,IActive
    {

        public override Task InsertOrUpdateAsync(TEntity model)
        {
            if (model.Id == null)
            {
                model.Active = Constant.Active;
            }
            return base.InsertOrUpdateAsync(model);
        }
    }
}
