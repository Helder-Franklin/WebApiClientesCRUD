using WebApiClientes.Models.Requests;

namespace WebApiClientes.Models.Responses.Success;

public class CustomerResponse
{
    public Guid Id { get; set; }
    public ExternalCustomerModel? Customer { get; set; }
}
