using Application.Visitors.SaveVisitorInfo;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using UAParser;

namespace WebSite.EndPoint.Utilities.Filters;

public class SaveVisitorFilter : IActionFilter
{
    private readonly ISaveVisitorInfoService _infoService;

    public SaveVisitorFilter(ISaveVisitorInfoService infoService)
    {
        _infoService = infoService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
        var actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
        var controllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
        var userAgent = context.HttpContext.Request.Headers["User-Agent"];
        var uaParser = Parser.GetDefault();
        ClientInfo clientInfo = uaParser.Parse(userAgent);
        var referer = context.HttpContext.Request.Headers["Referer"].ToString();
        var currentUrl = context.HttpContext.Request.Path;
        var requert = context.HttpContext.Request;

        _infoService.Execute(new RequestSaveVisitorInfoDto()
        {
            Browser = new VisitorVersionDto()
            {
                Family = clientInfo.UA.Family,
                Version = $"{clientInfo.UA.Major}.{clientInfo.UA.Minor}.{clientInfo.UA.Patch}",
            },
            CurrentLink = currentUrl,
            Device = new DeviceDto()
            {
                Brand = clientInfo.Device.Brand,
                Family = clientInfo.Device.Family,
                IsSpider = clientInfo.Device.IsSpider,
                Model = clientInfo.Device.Model,
            },
            Ip = ip,
            Method = requert.Method,
            OperationSystem = new VisitorVersionDto()
            {
                Family = clientInfo.OS.Family,
                Version = $"{clientInfo.OS.Major}.{clientInfo.OS.Minor}.{clientInfo.OS.Patch}",
            },
            PhysicalPath = $"{controllerName}/{actionName}",
            Protocol = requert.Protocol,
            ReferrerLink = referer,
        });
    }
}