using Microsoft.AspNetCore.SignalR;

namespace RescueTalk.Dispatcher.Hubs
{
    public class AmbulanceHub : Hub
    {
        public async Task SendLocation(Guid ambulanceId, double latitude, double longitude)
        {
            await Clients.All.SendAsync("ReceiveLocation", ambulanceId, latitude, longitude);
        }
    }
}
