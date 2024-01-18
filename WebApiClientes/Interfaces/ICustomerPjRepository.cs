using WebApiClientes.Models;

namespace WebApiClientes.Interfaces;

public interface ICustomerPjRepository
{
    public List<CustomerPj> Select(Func<CustomerPj, bool> wherefilter);
    public void Insert(CustomerPj clientePj);
    public CustomerPj Update(Func<CustomerPj, bool> wherefilter, CustomerPj clientePj);
    public void Delete(Func<CustomerPj, bool> wherefilter);
}
