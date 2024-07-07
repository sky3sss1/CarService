using Microsoft.AspNetCore.SignalR;

namespace CarParking.API.Hubs
{
    public class FeedbackHub : Hub
    {
        public async Task SendFeedback(Guid userId, string text)
        {
            await Clients.All.SendAsync("ReceiveFeedback", userId, text);
        }
    }
}