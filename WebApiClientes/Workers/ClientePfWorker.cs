using WebApiClientes.Exceptions;
using WebApiClientes.Interfaces;
using WebApiClientes.Models.Requests;
using WebApiClientes.Models.Responses.Success;
using WebApiClientes.Utils;

namespace WebApiClientes.Workers;

internal class CustomerPfWorker : ICustomerWorker
{
    private readonly ICustomerPfRepository _repository;

    public CustomerPfWorker(ICustomerPfRepository repository)
    {
        _repository = repository;
    }

    public void Delete(string documentNumber)
    {
        throw new NotImplementedException();
    }

    public Guid Register(ExternalCustomerModel externalCustomerModel)
    {
        var customerToInsert = ExternalCutomerModelBinder.GetInternalCustomerPf(externalCustomerModel);
        _repository.Insert(customerToInsert);
        return customerToInsert.ExternalId;
    }

    public CustomerResponse Search(string documentNumber)
    {
        var selectResult = _repository.Select(c => c.Cpf == documentNumber).FirstOrDefault() ?? throw new RespositoryException();
        var response = ExternalCutomerModelBinder.GetCustomerResponsePf(selectResult);
        return response;
    }

    public CustomerResponse Update(ExternalCustomerModel externalCustomerModel)
    {
        var updatedCustomer = ExternalCutomerModelBinder.GetInternalCustomerPf(externalCustomerModel);
        var selectResult = _repository.Update(c => c.Cpf == externalCustomerModel.NumeroDocumento, updatedCustomer);
        var response = ExternalCutomerModelBinder.GetCustomerResponsePf(selectResult);
        return response;
    }
}
