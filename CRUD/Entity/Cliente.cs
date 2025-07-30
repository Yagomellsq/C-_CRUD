using System.ComponentModel.DataAnnotations;

namespace CRUD.Entity;

public class Cliente
{
    [Key]
    public int? Id { get; init; }
    [StringLength(50)]
    public string? Nome { get; set; }
    [StringLength(50)]
    public string? Email { get; set; }
    [StringLength(50)]
    public string? Telefone { get; set; }

    public override string ToString()
    {
        return "Nome: " + Nome + 
               " \nEmail: " + Email + 
               " \nTelefone: " + Telefone;
    }
}