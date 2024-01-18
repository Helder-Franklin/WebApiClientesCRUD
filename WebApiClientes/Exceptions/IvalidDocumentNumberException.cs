using WebApiClientes.Resources;

namespace WebApiClientes.Exceptions;

public class InvalidDocumentNumberException : Exception
{
    public InvalidDocumentNumberException(string documentNumber) : base(string.Format(ErrorResponseMessages.InvalidDocumentNumberError, documentNumber))
    {
    }
}
