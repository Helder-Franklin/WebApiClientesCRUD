using WebApiClientes.Exceptions;

namespace WebApiClientes.Models.Responses.Error;

public class InvalidDocumentNumberError : BaseError
{
    public InvalidDocumentNumberError(InvalidDocumentNumberException ex) : base(ex.Message)
    {

    }
}
