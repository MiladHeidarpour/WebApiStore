using Application.Interfaces.Contexts;
using Domain.Orders;
using Domain.Payments;
using Microsoft.EntityFrameworkCore;

namespace Application.Payments;

public interface IPaymentService
{
    PaymentOfOrderDto PayForOrder(int orderId);
    PaymentDto GetPayment(Guid id);
    bool VerifyPayment(Guid id, string authority, long refId);

}

public class PaymentService : IPaymentService
{
    private readonly IDataBaseContext _context;
    private readonly IIdentityDatabaseContext _identityContext;

    public PaymentService(IDataBaseContext context, IIdentityDatabaseContext identityContext)
    {
        _context = context;
        _identityContext = identityContext;
    }

    public PaymentOfOrderDto PayForOrder(int orderId)
    {
        var order = _context.Orders.Include(p => p.OrderItems)
            .Include(p=>p.AppliedDiscount)
            .SingleOrDefault(p => p.Id == orderId);
        if (order == null)
        {
            throw new Exception("");
        }

        var payment = _context.Payments.SingleOrDefault(p => p.OrderId == order.Id);

        if (payment == null)
        {
            payment = new Payment(order.TotalPrice(), order.Id,"");
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        return new PaymentOfOrderDto()
        {
            Amount = payment.Amount,
            PaymentId = payment.Id,
            PaymentMethod = order.PaymentMethod,
        };
    }

    public PaymentDto GetPayment(Guid id)
    {
        var payment = _context.Payments
            .Include(p => p.Order)
            .ThenInclude(p => p.OrderItems)
            .Include(p=>p.Order)
            .ThenInclude(p=>p.AppliedDiscount)
            .SingleOrDefault(p => p.Id == id);

        var user = _identityContext.Users.SingleOrDefault(p => p.Id == payment.Order.UserId);

        string description = $"پرداخت سفارش شماره {payment.OrderId} " + Environment.NewLine;
        description += "محصولات" + Environment.NewLine;
        foreach (var item in payment.Order.OrderItems.Select(p => p.ProductName))
        {
            description += $" -{item}";
        }

        PaymentDto paymentDto = new PaymentDto()
        {
            Amount = payment.Order.TotalPrice(),
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            UserId = user.Id,
            Id = payment.Id,
            Description = description,
        };
        return paymentDto;
    }

    public bool VerifyPayment(Guid id, string authority, long refId)
    {
        var payment = _context.Payments.Include(p => p.Order).SingleOrDefault(p => p.Id == id);
        if (payment==null)
        {
            throw new Exception("");
        }

        payment.Order.PaymentDone();
        payment.PaymentIsDone(authority, refId);
        _context.SaveChanges();
        return true;
    }
}

public class PaymentOfOrderDto
{
    public Guid PaymentId { get; set; }
    public int Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}

public class PaymentDto
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public int Amount { get; set; }
    public string UserId { get; set; }

}