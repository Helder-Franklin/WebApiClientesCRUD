namespace WebApiClientes.Exceptions;

public class CustomInternalServerErrorException : Exception
{
    public CustomInternalServerErrorException(string? message) : base($"Ocorreu um erro de execução: {message}")
    {

    }
}
