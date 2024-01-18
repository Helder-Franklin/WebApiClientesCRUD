namespace WebApiClientes.Models.Responses.Error;

public abstract class BaseError
{
    protected BaseError(string message)
    {
        Message = message;
    }

    public string Message { get; }
}