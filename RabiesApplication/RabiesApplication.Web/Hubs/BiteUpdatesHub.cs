using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace RabiesApplication.Web.Hubs
{
    public class BiteUpdatesHub : Hub
    {
        [HubMethodName("UpdateClients")]
        public static void BiteUpdates()
        {
            //Some logic to push out the new bite update
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BiteUpdatesHub>();

            // the update client method will update the connected client about 
            // any recent changes in the server data
            context.Clients.All.updateClients();
        }
    }
}