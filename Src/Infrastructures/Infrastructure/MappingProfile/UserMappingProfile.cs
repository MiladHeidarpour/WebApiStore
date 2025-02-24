using Application.Users;
using AutoMapper;
using Domain.Users;

namespace Infrastructure.MappingProfile;

public class UserMappingProfile:Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserAddress, UserAddressDto>().ReverseMap();
        CreateMap<UserAddress, AddUserAddressDto>().ReverseMap();
    }
}