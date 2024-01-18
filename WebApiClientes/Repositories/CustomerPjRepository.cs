using WebApiClientes.Fake;
using WebApiClientes.Interfaces;
using WebApiClientes.Models;

namespace WebApiClientes.Repositories;

public class CustomerPjRepository : ICustomerPjRepository
{
    public void Delete(Func<CustomerPj, bool> wherefilter)
    {
        var cliente = FakeDatabase.CustomersPj.First(wherefilter);
        FakeDatabase.CustomersPj.Remove(cliente);
    }

    public void Insert(CustomerPj clientePj)
    {
        FakeDatabase.CustomersPj.Add(clientePj);
    }

    public List<CustomerPj> Select(Func<CustomerPj, bool> wherefilter)
    {
        return FakeDatabase.CustomersPj.Where(wherefilter).ToList();
    }

    CustomerPj ICustomerPjRepository.Update(Func<CustomerPj, bool> wherefilter, CustomerPj clientePj)
    {
        var cliente = FakeDatabase.CustomersPj.First(wherefilter);
        clientePj.ExternalId = cliente.ExternalId;

        FakeDatabase.CustomersPj.Remove(cliente);
        FakeDatabase.CustomersPj.Add(clientePj);

        return clientePj;
    }
}
