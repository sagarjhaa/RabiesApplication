using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = RabiesApplication.Models.Action;

namespace RabiesApplication.Web.Repositories
{
    public class ActionRepository : AuditRepository<Action>
    {
        public void OnPropertyChanged(object sender,EventArgs e)
        {
            Action action = new Action();
            action.BiteId = "a8556114-015c-4c47-bc8e-68fe5582653a";
            action.Comments = "Event fired guys";
            action.ActionType = "Message";
            base.InsertOrUpdateAsync(action);
            base.SaveChangesAsync();
        }
    }
}
