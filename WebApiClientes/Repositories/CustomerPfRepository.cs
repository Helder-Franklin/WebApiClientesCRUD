using WebApiClientes.Fake;
using WebApiClientes.Interfaces;
using WebApiClientes.Models;

namespace WebApiClientes.Repositories;

public class CustomerPfRepository : ICustomerPfRepository
{
    public void Delete(Func<CustomerPf, bool> wherefilter)
    {
        var cliente = FakeDatabase.CustomersPf.First(wherefilter);
        FakeDatabase.CustomersPf.Remove(cliente);
    }

    public void Insert(CustomerPf clientePf)
    {
        FakeDatabase.CustomersPf.Add(clientePf);
    }

    public List<CustomerPf> Select(Func<CustomerPf, bool> wherefilter)
    {
        return FakeDatabase.CustomersPf.Where(wherefilter).ToList();
    }

    CustomerPf ICustomerPfRepository.Update(Func<CustomerPf, bool> wherefilter, CustomerPf clientePf)
    {
        var cliente = FakeDatabase.CustomersPf.First(wherefilter);
        clientePf.ExternalId = cliente.ExternalId;

        FakeDatabase.CustomersPf.Remove(cliente);
        FakeDatabase.CustomersPf.Add(clientePf);

        return clientePf;
    }
}
