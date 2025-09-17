using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;

namespace FilmTicketApp.Hubs
{
    [Authorize]
    public class PriceUpdateHub : Hub
    {
        public async Task JoinPriceUpdates()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "PriceUpdates");
        }

        public async Task LeavePriceUpdates()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "PriceUpdates");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "PriceUpdates");
            await base.OnDisconnectedAsync(exception);
        }
    }
}