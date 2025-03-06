using Application.Orders.CustomerOrdersService;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Customers.Controllers;

[Authorize]
[Area("Customers")]
public class OrderController : Controller
{
    private readonly ICustomerOrderService _customerOrderService;
    private readonly UserManager<User> _userManager;

    public OrderController(ICustomerOrderService customerOrderService, UserManager<User> userManager)
    {
        _customerOrderService = customerOrderService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var user = _userManager.GetUserAsync(User).Result;
        var orders = _customerOrderService.GetMyOrders(user.Id);
        return View(orders);
    }
}