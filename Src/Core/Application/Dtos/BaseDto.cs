namespace Application.Dtos;

public class BaseDto<T>
{
    public T Data { get; private set; }
    public List<string> Message { get; private set; }
    public bool IsSuccess { get; private set; }
    public BaseDto(bool IsSuccess, List<string> Message, T Data)
    {
        this.IsSuccess = IsSuccess;
        this.Message = Message;
        this.Data = Data;
    }
}
public class BaseDto
{
    public List<string> Message { get; private set; }
    public bool IsSuccess { get; private set; }

    public BaseDto(bool IsSuccess, List<string> Message)
    {
        this.IsSuccess = IsSuccess;
        this.Message = Message;
    }
}
