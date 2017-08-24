using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RabiesApplication.Web.Models;
using Action = RabiesApplication.Models.Action;

namespace RabiesApplication.Web.Repositories
{
    public class ActionRepository : ActiveRepository<Action>
    {
        public IEnumerable<Action> GetActionsByBiteId(string biteId)
        {
            if (biteId == null)
            {
                return null;
            }

            return All().Where(a=> a.Active.Equals(Constant.Active)).Where(a => a.BiteId.Equals(biteId)).OrderBy(a => a.RecordCreated);
        }
    }
}
