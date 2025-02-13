using Application.Interfaces.Contexts;
using Domain.Visitors;
using MongoDB.Driver;

namespace Application.Visitors.SaveVisitorInfo;

public class SaveVisitorInfoService : ISaveVisitorInfoService
{
    private readonly IMongoDbContext<Visitor> _dbContext;
    private readonly IMongoCollection<Visitor> _collection;

    public SaveVisitorInfoService(IMongoDbContext<Visitor> dbContext)
    {
        _dbContext = dbContext;
        _collection = _dbContext.GetCollection();
    }

    public void Execute(RequestSaveVisitorInfoDto request)
    {
        _collection.InsertOne(new Visitor()
        {
            CurrentLink = request.CurrentLink,
            Ip = request.Ip,
            Method = request.Method,
            PhysicalPath = request.PhysicalPath,
            Protocol = request.Protocol,
            ReferrerLink = request.ReferrerLink,
            Device = new Device()
            {
                Brand = request.Device.Brand,
                Family = request.Device.Family,
                Model = request.Device.Model,
                IsSpider = request.Device.IsSpider,
            },
            Browser = new VisitorVersion()
            {
                Family = request.Browser.Family,
                Version = request.Browser.Version
            },
            OperationSystem = new VisitorVersion()
            {
                Family = request.OperationSystem.Family,
                Version = request.OperationSystem.Version
            }
        });
    }
}