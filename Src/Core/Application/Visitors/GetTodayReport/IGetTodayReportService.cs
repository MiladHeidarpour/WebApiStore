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

        var todayPageViewList = _collection.AsQueryable().Where(p => p.Time >= start && p.Time < end).Select(p => new { p.Time }).ToList();
        VisitCountDto visitPerHour = new VisitCountDto()
        {
            Display = new string[24],
            Value = new int[24],
        };

        for (int i = 0; i <= 23; i++)
        {
            visitPerHour.Display[i] = $"H-{i}";
            visitPerHour.Value[i] = todayPageViewList.Where(p => p.Time.Hour == i).Count();
        }


        DateTime MonthStart = DateTime.Now.Date.AddDays(-30);
        DateTime MonthEnds = DateTime.Now.Date.AddDays(1);

        var month_PageViewList = _collection.AsQueryable().Where(p => p.Time >= MonthStart && p.Time < MonthEnds).Select(p => new { p.Time }).ToList();

        VisitCountDto visitPerDay = new VisitCountDto()
        {
            Display = new string[31],
            Value = new int[31],
        };

        for (int i = 0; i <= 30; i++)
        {
            var currentDay=DateTime.Now.AddDays(i*(-1));
            visitPerDay.Display[i] = i.ToString();
            visitPerDay.Value[i] = month_PageViewList.Where(p => p.Time.Date == currentDay.Date).Count();
        }

        return new ResultTodayReportDto()
        {
            GeneralStates = new GeneralStateDto()
            {
                TotalVisitors = allVisitorCount,
                TotalPageViews = allPageViewCount,
                PageViewsPerVisit = GetAvg(allPageViewCount, allVisitorCount),
                VisitPerDay = visitPerDay,
            },
            Today = new TodayDto()
            {
                PageViews = todayPageViewCount,
                Visitors = todayVisitorCount,
                ViewsPerVisitor = GetAvg(todayPageViewCount, todayVisitorCount),
                VisitPerHour = visitPerHour,
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
    public VisitCountDto VisitPerDay { get; set; }
}

public class TodayDto
{
    public long PageViews { get; set; }
    public long Visitors { get; set; }
    public float ViewsPerVisitor { get; set; }
    public VisitCountDto VisitPerHour { get; set; }
}

public class VisitCountDto
{
    public string[] Display { get; set; }
    public int[] Value { get; set; }
}