namespace WebApiClientes.Exceptions;

public class CustomDependencyInjectionException : Exception
{
    public CustomDependencyInjectionException(string? message) : base(message)
    {
    }
}
