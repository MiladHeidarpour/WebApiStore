using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Contexts;

public interface IIdentityDatabaseContext
{
    DbSet<User> Users { get; set; }
}