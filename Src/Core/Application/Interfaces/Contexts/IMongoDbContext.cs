using MongoDB.Driver;

namespace Application.Interfaces.Contexts;

public interface IMongoDbContext<T>
{
    public IMongoCollection<T> GetCollection();
}