﻿using Domain.Orders;

namespace Domain.Discounts;

public class DiscountUsageHistory
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public virtual Discount Discount { get; set; }
    public int DiscountId { get; set; }
    public virtual Order Order { get; set; }
    public int OrderId { get; set; }
}