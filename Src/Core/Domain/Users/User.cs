
using Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Domain.Users;

[Auditable]
public class User:IdentityUser
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
}