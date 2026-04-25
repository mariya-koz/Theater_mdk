using Microsoft.AspNetCore.SignalR;
using Theater_mdk.Models;

namespace Theater_mdk.Hubs
{
    public class TicketHub : Hub
    {
        public async Task SendTicketUpdate(Ticket ticket)
        {
            await Clients.All.SendAsync("TicketUpdated", ticket);
        }

    }
}
