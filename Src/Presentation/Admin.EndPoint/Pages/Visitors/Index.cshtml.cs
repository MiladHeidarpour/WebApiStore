using Application.Visitors.GetTodayReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Admin.EndPoint.Pages.Visitors;

public class IndexModel : PageModel
{
    private readonly IGetTodayReportService _todayReport;
    public ResultTodayReportDto ResultTodayReport;
    public IndexModel(IGetTodayReportService todayReport)
    {
        _todayReport = todayReport;
    }

    public void OnGet()
    {
        ResultTodayReport = _todayReport.Execute();
    }
}