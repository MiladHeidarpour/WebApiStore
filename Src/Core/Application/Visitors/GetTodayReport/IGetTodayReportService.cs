using Application.Interfaces.Contexts;
using Domain.Visitors;
using MongoDB.Driver;

namespace Application.Visitors.GetTodayReport;

public interface IGetTodayReportService
{
    ResultTodayReportDto Execute();
}
public class GetTodayReportService : IGetTodayReportService
{
    private readonly IMongoDbContext<Visitor> _dbContext;
    private readonly IMongoCollection<Visitor> _collection;

    public GetTodayReportService(IMongoDbContext<Visitor> dbContext)
    {
        _dbContext = dbContext;
        _collection = _dbContext.GetCollection();
    }

    public ResultTodayReportDto Execute()
    {
        DateTime start = DateTime.Now.Date;
        DateTime end = DateTime.Now.AddDays(1);

        var todayPageViewCount = _collection.AsQueryable().Where(p => p.Time >= start && p.Time < end).LongCount();
        var todayVisitorCount = _collection.AsQueryable().Where(p => p.Time >= start && p.Time < end).GroupBy(p => p.VisitorId).LongCount();
        var allPageViewCount = _collection.AsQueryable().LongCount();
        var allVisitorCount = _collection.AsQueryable().GroupBy(p => p.VisitorId).LongCount();

        return new ResultTodayReportDto()
        {
            GeneralStates = new GeneralStateDto()
            {
                TotalVisitors = allVisitorCount,
                TotalPageViews = allPageViewCount,
                PageViewsPerVisit = GetAvg(allPageViewCount, allVisitorCount),
            },
            Today = new TodayDto()
            {
                PageViews = todayPageViewCount,
                Visitors = todayVisitorCount,
                ViewsPerVisitor = GetAvg(todayPageViewCount, todayVisitorCount),
            }
        };
    }

    private float GetAvg(long visitPage, long visitor)
    {
        if (visitor == 0)
        {
            return 0;
        }
        else
        {
            return visitPage / visitor;
        }
    }
}
public class ResultTodayReportDto
{
    public GeneralStateDto GeneralStates { get; set; }
    public TodayDto Today { get; set; }
}



public class GeneralStateDto
{
    public long TotalPageViews { get; set; }
    public long TotalVisitors { get; set; }
    public float PageViewsPerVisit { get; set; }
}

public class TodayDto
{
    public long PageViews { get; set; }
    public long Visitors { get; set; }
    public float ViewsPerVisitor { get; set; }
}