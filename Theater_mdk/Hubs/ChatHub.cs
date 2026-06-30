using Microsoft.AspNetCore.SignalR;

namespace Theater_mdk.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("Receive", user, message);
        }

    }
}
