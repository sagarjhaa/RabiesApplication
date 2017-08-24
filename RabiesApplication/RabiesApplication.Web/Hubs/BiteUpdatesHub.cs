using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using RabiesApplication.Models;
using RabiesApplication.Web.Repositories;


namespace RabiesApplication.Web.Hubs
{
    [HubName("biteupdateshub")]
    public class BiteUpdatesHub : Hub
    {
        public async Task NotifyUpdates()
        {
            //Some logic to push out the new bite update
            var context = GlobalHost.ConnectionManager.GetHubContext<BiteUpdatesHub>();
            var biteRepository = new BiteRepository();

            // the update client method will update the connected client about 
            // any recent changes in the server data
            context.Clients.All.updateClients(await biteRepository.All().ToListAsync());
        }

        //Todo : Need a better function to notify things that are need to be shown on the screen.
        // 1) Show today's action items and past items if anything left.

        

    }

}