﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RabiesApplication.Web.Models;
using RabiesApplication.Web.ViewModels;
using Action = RabiesApplication.Models.Action;

namespace RabiesApplication.Web.Repositories
{
   

    public class ActionRepository : ActiveRepository<Action>
    {
        public IEnumerable<ActionListViewModel> GetActionsByBiteId(string biteId)
        {
            if (biteId == null)
            {
                return null;
            }
            return  (from a in Context.Actions
                where a.Active.Equals(Constant.Active)
                where a.BiteId.Equals(biteId)
                orderby a.RecordCreated
                select new ActionListViewModel()
                {
                    Id = a.Id,
                    BiteId = a.BiteId,
                    DocumentId = a.DocumentId ,//== null ? a.DocumentId: a.DocumentId,
                    ActionType = a.ActionType,
                    Comments = a.Comments,
                    RecordCreated = a.RecordCreated
                }).ToList();
            
            //return All().Where(a=> a.Active.Equals(Constant.Active))
            //                .Where(a => a.BiteId.Equals(biteId))
            //                .OrderBy(a => a.RecordCreated);


            
            
        }
    }
}
