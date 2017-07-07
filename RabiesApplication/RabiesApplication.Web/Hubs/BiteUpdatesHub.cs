using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RabiesApplication.Web.Repositories;


namespace RabiesApplication.Web.Hubs
{
    [HubName("biteupdateshub")]
    public class BiteUpdatesHub : Hub
    {
        [HubMethodName("UpdateClients")]
        public async Task NotifyUpdates()
        {
            //Some logic to push out the new bite update
            var context = GlobalHost.ConnectionManager.GetHubContext<BiteUpdatesHub>();
            var biteRepository = new BiteRepository();

            // the update client method will update the connected client about 
            // any recent changes in the server data
            var bites = await biteRepository.All().ToListAsync();
            context.Clients.All.updateClients(bites);
        }
    }
}