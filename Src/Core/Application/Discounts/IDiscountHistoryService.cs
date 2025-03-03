using Application.Dtos;
using Application.Interfaces.Contexts;
using Common;
using Domain.Discounts;
using Domain.Orders;

namespace Application.Discounts;

public interface IDiscountHistoryService
{
    void InsertDiscountUsageHistory(int discountId, int orderId);
    DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId);
    PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId,string? userId, int pageIndex,int pageSize);
}

public class DiscountHistoryService : IDiscountHistoryService
{
    private readonly IDataBaseContext _context;

    public DiscountHistoryService(IDataBaseContext context)
    {
        _context = context;
    }

    public void InsertDiscountUsageHistory(int discountId, int orderId)
    {
        var order = _context.Orders.Find(orderId);
        var discount = _context.Discounts.Find(discountId);

        DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory()
        {
            CreatedOn = DateTime.Now,
            Discount = discount,
            Order = order,
        };
        _context.DiscountUsageHistories.Add(discountUsageHistory);
        _context.SaveChanges();
    }

    public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
    {
        if (discountUsageHistoryId == 0)
            return null;

        var discountUsage = _context.DiscountUsageHistories.Find(discountUsageHistoryId);
        return discountUsage;
    }

    public PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId, string? userId, int pageIndex, int pageSize)
    {
        var query = _context.DiscountUsageHistories.AsQueryable();

        if (discountId.HasValue && discountId.Value > 0)
            query = query.Where(p => p.DiscountId == discountId.Value);

        if (!string.IsNullOrEmpty(userId))
            query = query.Where(p => p.Order != null && p.Order.UserId == userId);

        query = query.OrderByDescending(c => c.CreatedOn);
        var pagedItems = query.PagedResult(pageIndex, pageSize, out int rowCount);
        return new PaginatedItemsDto<DiscountUsageHistory>(pageIndex, pageSize, rowCount, query.ToList());
    }
}