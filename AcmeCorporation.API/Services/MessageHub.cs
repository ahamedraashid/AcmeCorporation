using System.Threading.Tasks;
using AcmeCorporation.API.Data.Models;
using Microsoft.AspNetCore.SignalR;

namespace AcmeCorporation.API.Services
{
    public class MessageHub : Hub
    {
        public async Task NewMessage(Transaction transaction)  
        {  
            await Clients.All.SendAsync("MessageReceived", transaction);  
        }
    }
}