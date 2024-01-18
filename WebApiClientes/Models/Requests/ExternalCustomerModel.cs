namespace WebApiClientes.Models.Requests;

public class ExternalCustomerModel
{
    public string NumeroDocumento { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public Endereco? Endereco { get; set; }
    public string Telefone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
