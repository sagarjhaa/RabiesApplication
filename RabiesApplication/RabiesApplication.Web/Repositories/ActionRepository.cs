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
    public class ActionDTO
    {
        public string Id { get; set; }
        public string BiteId { get; set; }
        public string ActionType { get; set; }
        public string Comments { get; set; }
        public string DocumentId { get; set; }
    }


    public class ActionRepository : ActiveRepository<Action>
    {
        public IEnumerable<ActionDTO> GetActionsByBiteId(string biteId)
        {
            if (biteId == null)
            {
                return null;
            }
            return  (from a in Context.Actions
                where a.Active.Equals(Constant.Active)
                where a.BiteId.Equals(biteId)
                orderby a.RecordCreated
                select new ActionDTO()
                {
                    Id = a.Id,
                    BiteId = a.BiteId,
                    DocumentId = a.DocumentId ,//== null ? a.DocumentId: a.DocumentId,
                    ActionType = a.ActionType,
                    Comments = a.Comments
                }).ToList();
            
            //return All().Where(a=> a.Active.Equals(Constant.Active))
            //                .Where(a => a.BiteId.Equals(biteId))
            //                .OrderBy(a => a.RecordCreated);


            
            
        }
    }
}
