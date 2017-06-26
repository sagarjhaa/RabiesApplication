﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabiesApplication.Models;
using RabiesApplication.Web.Models;

namespace RabiesApplication.Web.Repositories
{

    public abstract class AuditRepository<TEntity> : ActiveRepository<TEntity>
        where TEntity : class, IModel, IAuditable,IActive
    {

        public override Task InsertOrUpdateAsync(TEntity model)
        {
            // ensure organization is set on model
            var user = new UserRepository().GetUserID(System.Web.HttpContext.Current.User);
            if (model.Id == null)
            {
                model.RecordCreated = DateTimeOffset.Now;
                model.EmployeeCreatedId = user;
            }
            else
            {
                model.RecordEdited = DateTimeOffset.Now;
                model.EmployeeEditedId = user;
            }
            return base.InsertOrUpdateAsync(model);
        }
    }
}
