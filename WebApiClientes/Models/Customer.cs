namespace WebApiClientes.Models;

public abstract class Customer
{
    public Guid ExternalId { get; set; }
    public int Id { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
