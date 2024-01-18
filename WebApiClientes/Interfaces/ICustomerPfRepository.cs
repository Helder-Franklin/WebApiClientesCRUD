using WebApiClientes.Models;

namespace WebApiClientes.Interfaces;

public interface ICustomerPfRepository
{
    public List<CustomerPf> Select(Func<CustomerPf, bool> wherefilter);
    public void Insert(CustomerPf clientePf);
    public CustomerPf Update(Func<CustomerPf, bool> wherefilter, CustomerPf clientePf);
    public void Delete(Func<CustomerPf, bool> wherefilter);
}
