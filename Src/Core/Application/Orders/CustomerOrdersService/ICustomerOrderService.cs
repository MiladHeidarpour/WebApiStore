using Application.Interfaces.Contexts;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.CustomerOrdersService;

public interface ICustomerOrderService
{
    List<MyOrderDto> GetMyOrders(string userId);
}

public class CustomerOrderService:ICustomerOrderService
{
    private readonly IDataBaseContext _context;

    public CustomerOrderService(IDataBaseContext context)
    {
        _context = context;
    }

    public List<MyOrderDto> GetMyOrders(string userId)
    {

        //var order = _context.Orders.FirstOrDefaultAsync();
        //_context.Entry(order).Property("Name").CurrentValue;

        var orders = _context.Orders
            .Include(p => p.OrderItems)
            .Where(p => p.UserId == userId)
            .OrderByDescending(p=>p.Id)
            .Select(p=>new MyOrderDto()
            {
                Id = p.Id,
                Date = _context.Entry(p).Property("InsertTime").CurrentValue.ToString(),
                Price = p.TotalPrice(),
                OrderStatus = p.OrderStatus,
                PaymentStatus = p.PaymentStatus,
            }).ToList();

        return orders;
    }
}

public class MyOrderDto
{
    public int Id { get; set; }
    public string Date { get; set; }
    public int Price { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}