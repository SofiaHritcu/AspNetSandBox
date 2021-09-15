using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace AspNetSandBox
{
    internal class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}