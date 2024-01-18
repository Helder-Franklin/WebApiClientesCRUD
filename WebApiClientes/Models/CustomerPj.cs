using System.ComponentModel.DataAnnotations;

namespace WebApiClientes.Models;

public class CustomerPj : Customer
{
    [Required]
    [Key]
    public string Cnpj { get; set; } = string.Empty;
    public string RazaoSocial { get; set; } = string.Empty;
    public Endereco? Endereco { get; set; }
}
