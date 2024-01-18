using System.ComponentModel.DataAnnotations;

namespace WebApiClientes.Models;

public class CustomerPf : Customer
{
    [Required]
    [Key]
    public string Cpf { get; set; } = string.Empty;

    public string Nome { get; set; } = string.Empty;

    public Endereco? Endereco { get; set; }

}
