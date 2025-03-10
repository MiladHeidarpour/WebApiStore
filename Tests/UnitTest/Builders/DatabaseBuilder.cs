using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace UnitTest.Builders;

public class DatabaseBuilder
{
    internal DatabaseContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new DatabaseContext(options);
    }
}