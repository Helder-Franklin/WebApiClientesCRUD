using WebApiClientes.Models;

namespace WebApiClientes.Fake;

internal static class FakeDatabase
{
    public static List<CustomerPf> CustomersPf { get; set; } = new();
    public static List<CustomerPj> CustomersPj { get; set; } = new();
}
