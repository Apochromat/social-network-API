using SignalRSwaggerGen.Attributes;

namespace social_network_API.Hubs; 

using Microsoft.AspNetCore.SignalR;
 
[SignalRHub]
public class ChatHub : Hub
{
    public async Task Send(string message)
    {
        await this.Clients.All.SendAsync("Receive", message);
    }
}