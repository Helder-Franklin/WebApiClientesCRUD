using WebApiClientes.Models;
using WebApiClientes.Models.Requests;
using WebApiClientes.Models.Responses.Success;

namespace WebApiClientes.Utils;

internal static class ExternalCutomerModelBinder
{
    public static CustomerPf GetInternalCustomerPf(ExternalCustomerModel externalCustomerModel)
    {
        var result = new CustomerPf
        {
            Cpf = externalCustomerModel.NumeroDocumento,
            Email = externalCustomerModel.Email,
            Endereco = externalCustomerModel.Endereco,
            ExternalId = Guid.NewGuid(),
            Nome = externalCustomerModel.Nome,
            Telefone = externalCustomerModel.Telefone
        };

        return result;
    }

    public static CustomerPj GetInternalCustomerPj(ExternalCustomerModel externalCustomerModel)
    {
        var result = new CustomerPj
        {
            Cnpj = externalCustomerModel.NumeroDocumento,
            Email = externalCustomerModel.Email,
            Endereco = externalCustomerModel.Endereco,
            ExternalId = Guid.NewGuid(),
            RazaoSocial = externalCustomerModel.Nome,
            Telefone = externalCustomerModel.Telefone
        };

        return result;
    }
    public static CustomerResponse GetCustomerResponsePf(CustomerPf customer)
    {
        var externarCustomerModel = new ExternalCustomerModel
        {
            NumeroDocumento = customer.Cpf,
            Email = customer.Email,
            Endereco = customer.Endereco ?? throw new ArgumentNullException(nameof(customer), "O endereço está nulo"),
            Nome = customer.Nome,
            Telefone = customer.Telefone
        };
        var result = new CustomerResponse
        {
            Customer = externarCustomerModel,
            Id = customer.ExternalId
        };

        return result;
    }

    public static CustomerResponse GetCustomerResponsePj(CustomerPj customer)
    {
        var externarCustomerModel = new ExternalCustomerModel
        {
            NumeroDocumento = customer.Cnpj,
            Email = customer.Email,
            Endereco = customer.Endereco ?? throw new ArgumentNullException(nameof(customer), "O endereço está nulo"),
            Nome = customer.RazaoSocial,
            Telefone = customer.Telefone
        };
        var result = new CustomerResponse
        {
            Customer = externarCustomerModel,
            Id = customer.ExternalId
        };

        return result;
    }
}
