using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Users;

namespace Application.Users;

public interface IUserAddressService
{
    void AddNewAddress(AddUserAddressDto address);
    List<UserAddressDto> GetAddresses(string userId);
}

public class UserAddressService : IUserAddressService
{
    private readonly IDataBaseContext _context;
    private readonly IMapper _mapper;

    public UserAddressService(IDataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void AddNewAddress(AddUserAddressDto address)
    {
        var data=_mapper.Map<UserAddress>(address);
        _context.UserAddresses.Add(data);
        _context.SaveChanges();
    }

    public List<UserAddressDto> GetAddresses(string userId)
    {
        var addresses = _context.UserAddresses.Where(p=>p.UserId==userId);
        var data= _mapper.Map<List<UserAddressDto>>(addresses);
        return data;
    }
}

public class UserAddressDto
{
    public int  Id { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string PostalAddress { get; set; }
    public string ReciverName { get; set; }
}
public class AddUserAddressDto
{
    public string State { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string PostalAddress { get; set; }
    public string UserId { get; set; }
    public string ReciverName { get; set; }
}