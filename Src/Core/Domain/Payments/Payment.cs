using Domain.Attributes;
using Domain.Orders;

namespace Domain.Payments;

[Auditable]
public class Payment
{
    public Guid Id { get; set; }
    public int Amount { get; private set; }
    public bool IsPay { get; private set; } = false;
    public DateTime? DatePay { get; private set; } = null;
    public string Authority { get; private set; }
    public long RefId { get; private set; } = 0;
    public int OrderId { get;private set; }
    public Order Order { get;private set; }


    public Payment(int amount, int orderId,string authority)
    {
        Amount = amount;
        OrderId = orderId;
        Authority=authority;
    }

    public void PaymentIsDone(string authority, long refId)
    {
        IsPay = true;
        DatePay=DateTime.Now;
        Authority=authority;
        RefId=refId;
    }
}