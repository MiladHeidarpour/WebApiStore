using Application.Visitors.VisitorOnline;
using Microsoft.AspNetCore.SignalR;

namespace WebSite.EndPoint.Hubs;

public class OnlineVisitorHub : Hub
{
    private readonly IVisitorOnlineService _service;
    public OnlineVisitorHub(IVisitorOnlineService service)
    {
        _service = service;
    }
    public override Task OnConnectedAsync()
    {
        string visitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
        _service.ConnectUser(visitorId); /*Context.ConnectionId*/
        var count = _service.GetCount();
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        string visitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
        _service.DisConnectUser(visitorId); /*Context.ConnectionId*/
        var count = _service.GetCount();
        return base.OnDisconnectedAsync(exception);
    }
}