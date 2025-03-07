namespace Application.Exceptions;

public class NotFoundException:Exception
{
    public NotFoundException(string entityName,object key):base($"Entity {entityName} with key : {key} was NOT FOUND.")
    {
        
    }
}