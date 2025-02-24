using Domain.Attributes;

namespace Domain.Users;

[Auditable]
public class UserAddress
{
    public int  Id { get;private set; }
    public string State { get;private set; }
    public string City { get;private set; }
    public string ZipCode { get;private set; }
    public string PostalAddress { get;private set; }
    public string UserId { get;private set; }
    public string ReciverName { get;private set; }

    public UserAddress( string state, string city, string zipCode, string postalAddress, string userId, string reciverName)
    {
        State = state;
        City = city;
        ZipCode = zipCode;
        PostalAddress = postalAddress;
        UserId = userId;
        ReciverName = reciverName;
    }

    private UserAddress()
    {
        
    }
}