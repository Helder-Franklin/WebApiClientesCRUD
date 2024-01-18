using WebApiClientes.Exceptions;
using WebApiClientes.Interfaces;
using WebApiClientes.Models.Requests;
using WebApiClientes.Models.Responses.Success;
using WebApiClientes.Utils;

namespace WebApiClientes.Workers;

internal class CustomerPjWorker : ICustomerWorker
{
    private readonly ICustomerPjRepository _repository;

    public CustomerPjWorker(ICustomerPjRepository repository)
    {
        _repository = repository;
    }

    public void Delete(string documentNumber)
    {
        throw new NotImplementedException();
    }

    public Guid Register(ExternalCustomerModel externalCustomerModel)
    {
        var customerToInsert = ExternalCutomerModelBinder.GetInternalCustomerPj(externalCustomerModel);
        _repository.Insert(customerToInsert);
        return customerToInsert.ExternalId;
    }

    public CustomerResponse Search(string documentNumber)
    {
        var selectResult = _repository.Select(c => c.Cnpj == documentNumber).FirstOrDefault() ?? throw new RespositoryException();
        var response = ExternalCutomerModelBinder.GetCustomerResponsePj(selectResult);
        return response;
    }

    public CustomerResponse Update(ExternalCustomerModel externalCustomerModel)
    {
        var updatedCustomer = ExternalCutomerModelBinder.GetInternalCustomerPj(externalCustomerModel);
        var selectResult = _repository.Update(c => c.Cnpj == externalCustomerModel.NumeroDocumento, updatedCustomer);
        var response = ExternalCutomerModelBinder.GetCustomerResponsePj(selectResult);
        return response;
    }
}
