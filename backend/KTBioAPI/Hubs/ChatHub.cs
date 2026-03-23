using Microsoft.AspNetCore.SignalR;

namespace KTBioAPI.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly Dictionary<string, string> _connectedUsers = new();

        public override async Task OnConnectedAsync()
        {
            var userName = Context.GetHttpContext()?.Request.Query["userName"].ToString() ?? "Anonymous";
            _connectedUsers[Context.ConnectionId] = userName;
            
            await Clients.All.SendAsync("UserConnected", userName);
            await Clients.All.SendAsync("ReceiveMessage", "System", $"{userName} a rejoint le chat");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (_connectedUsers.TryGetValue(Context.ConnectionId, out var userName))
            {
                _connectedUsers.Remove(Context.ConnectionId);
                await Clients.All.SendAsync("UserDisconnected", userName);
                await Clients.All.SendAsync("ReceiveMessage", "System", $"{userName} a quitté le chat");
            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendNotification(string title, string message, string type = "info")
        {
            await Clients.All.SendAsync("ReceiveNotification", new { title, message, type });
        }

        public async Task NotifyInventoryUpdate(int depotId, string productRef, int newQuantity)
        {
            await Clients.All.SendAsync("InventoryUpdated", new { depotId, productRef, newQuantity });
        }

        public async Task NotifyCriticalStock(string productRef, string depotName, int quantity)
        {
            await Clients.All.SendAsync("CriticalStockAlert", new { productRef, depotName, quantity });
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("UserJoinedGroup", groupName, _connectedUsers.GetValueOrDefault(Context.ConnectionId, "Anonymous"));
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("UserLeftGroup", groupName, _connectedUsers.GetValueOrDefault(Context.ConnectionId, "Anonymous"));
        }

        public async Task SendMessageToGroup(string groupName, string user, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", groupName, user, message);
        }

        public async Task GetConnectedUsers()
        {
            await Clients.Caller.SendAsync("ConnectedUsersList", _connectedUsers.Values.ToList());
        }
    }
}
