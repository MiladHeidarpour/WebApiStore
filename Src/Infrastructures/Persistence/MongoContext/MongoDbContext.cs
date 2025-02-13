using Application.Interfaces.Contexts;
using MongoDB.Driver;

namespace Persistence.MongoContext;

public class MongoDbContext<T> : IMongoDbContext<T>
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<T> _collection;

    public MongoDbContext()
    {
        var client = new MongoClient();
        _database = client.GetDatabase("VisitorDb");
        _collection = _database.GetCollection<T>(typeof(T).Name);
    }

    public IMongoCollection<T> GetCollection()
    {
        return _collection;
    }
}