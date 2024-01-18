using Microsoft.AspNetCore.Mvc;
using WebApiClientes.Exceptions;
using WebApiClientes.Interfaces;
using WebApiClientes.Models;
using WebApiClientes.Models.Requests;
using WebApiClientes.Models.Responses.Error;
using WebApiClientes.Resources;
using WebApiClientes.Utils;

namespace WebApiClientes.Controllers;

[ApiController]
[Route("clientes")]
public class ClienteController : ControllerBase
{
    private readonly Dictionary<CustomerType, ICustomerWorker> _customerWorkerMap;

    public ClienteController(Dictionary<CustomerType, ICustomerWorker> customerWorkerMap)
    {
        _customerWorkerMap = customerWorkerMap;
    }

    [HttpGet("obter-cliente")]
    public IActionResult Get(string documentNumber)
    {
        CustomerType customerType;
        try
        {
            customerType = GetCustomerType(documentNumber);

            var documento = _customerWorkerMap[customerType].Search(documentNumber);

            return Ok(documento);
        }
        catch (InvalidDocumentNumberException ex)
        {
            return BadRequest(new InvalidDocumentNumberError(ex));
        }
        catch
        {
            throw new CustomInternalServerErrorException(ErrorResponseMessages.ErrorDuringSearch);
        }
    }

    private static CustomerType GetCustomerType(string documentNumber)
    {
        if (CpfCnpjUtils.IsCpf(documentNumber))
        {
            return CustomerType.Pf;
        }

        if (CpfCnpjUtils.IsCnpj(documentNumber))
        {
            return CustomerType.Pj;
        }

        throw new InvalidDocumentNumberException(documentNumber);
    }


    [HttpPost("inserir-cliente")]
    public IActionResult Insert(ExternalCustomerModel externalCustomerModel)
    {
        CustomerType customerType;
        try
        {
            customerType = GetCustomerType(externalCustomerModel.NumeroDocumento);

            var response = _customerWorkerMap[customerType].Register(externalCustomerModel);

            return new CreatedResult(nameof(Get), response);
        }
        catch (InvalidDocumentNumberException ex)
        {
            return BadRequest(new InvalidDocumentNumberError(ex));
        }
        catch
        {
            throw new CustomInternalServerErrorException(ErrorResponseMessages.ErrorDuringInsertion);
        }
    }

    [HttpDelete("deletar-cliente")]
    public IActionResult Delete(string documentNumber)
    {
        CustomerType customerType;
        try
        {
            customerType = GetCustomerType(documentNumber);

            _customerWorkerMap[customerType].Delete(documentNumber);

            return Ok();
        }
        catch (InvalidDocumentNumberException ex)
        {
            return BadRequest(new InvalidDocumentNumberError(ex));
        }
        catch
        {
            throw new CustomInternalServerErrorException(ErrorResponseMessages.ErrorDuringDelete);
        }
    }

    [HttpPut("alterar-cliente")]
    public IActionResult Update(ExternalCustomerModel register)
    {
        CustomerType customerType;
        try
        {
            customerType = GetCustomerType(register.NumeroDocumento);

            var response = _customerWorkerMap[customerType].Update(register);

            return Ok(response);
        }
        catch (InvalidDocumentNumberException ex)
        {
            return BadRequest(new InvalidDocumentNumberError(ex));
        }
        catch
        {
            throw new CustomInternalServerErrorException(ErrorResponseMessages.ErrorDuringInsertion);
        }
    }
}
