using Application.Interfaces.Contexts;
using Domain.Visitors;
using MongoDB.Driver;

namespace Application.Visitors.VisitorOnline;

public class VisitorOnlineService : IVisitorOnlineService
{
    private readonly IMongoDbContext<OnlineVisitor> _context;
    private readonly IMongoCollection<OnlineVisitor> _collection;

    public VisitorOnlineService(IMongoDbContext<OnlineVisitor> context)
    {
        _context = context;
        _collection = _context.GetCollection();
    }
    public void ConnectUser(string ClientId)
    {
        var exist = _collection.AsQueryable().FirstOrDefault(p => p.ClientId == ClientId);
        if (exist == null)
        {
            _collection.InsertOne(new OnlineVisitor
            {
                ClientId = ClientId,
                Time = DateTime.Now,
            });
        }
    }

    public void DisConnectUser(string ClientId)
    {
        _collection.FindOneAndDelete(p => p.ClientId == ClientId);
    }

    public int GetCount()
    {
        return _collection.AsQueryable().Count();
    }
}