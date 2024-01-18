using WebApiClientes.Models.Requests;
using WebApiClientes.Models.Responses.Success;

namespace WebApiClientes.Interfaces;

public interface ICustomerWorker
{
    void Delete(string documentNumber);
    Guid Register(ExternalCustomerModel externalCustomerModel);
    CustomerResponse Search(string documentNumber);
    CustomerResponse Update(ExternalCustomerModel externalCustomerModel);
}
