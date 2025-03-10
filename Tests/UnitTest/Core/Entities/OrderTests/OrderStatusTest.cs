using Domain.Orders;
using UnitTest.Builders;

namespace UnitTest.Core.Entities.OrderTests;

public class OrderStatusTest
{
    [Fact]
    public void When_Order_Is_Delivered_OrderStatus_Changes_To_Delivered()
    {
        var builder = new OrderBuilder();
        var order = builder.CreateOrderWithDefaultValues();
        order.OrderDelivered();

        Assert.Equal(OrderStatus.Delivered,order.OrderStatus);
    }
}