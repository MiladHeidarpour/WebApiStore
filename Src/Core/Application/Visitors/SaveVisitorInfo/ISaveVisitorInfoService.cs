namespace Application.Visitors.SaveVisitorInfo;

public interface ISaveVisitorInfoService
{
    void Execute(RequestSaveVisitorInfoDto request);
}