using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class NotificationHub: Hub
    {
        public async Task<string> GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public async Task SendNotification(string message, string senderConnectionId)
        {
            await Clients.AllExcept(senderConnectionId).SendAsync("ReceiveNotification", message);
        }
    }
}
