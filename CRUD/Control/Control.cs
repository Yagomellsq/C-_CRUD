using CRUD.Data;
using CRUD.Entity;

namespace CRUD.Control;

public class Control
{
    private Crud? _context;

    private Cliente? _cliente;

    public Cliente? AdicionarCliente(string nome, string email, string telefone)
    {
        _context = new Crud();
        _cliente = new Cliente
        {
            Nome = nome,
            Email = email,
            Telefone = telefone
        };
        
        _context.Add(_cliente);
        _context.SaveChanges();
        
        return _cliente;
    }

    public Cliente? BuscarCliente(int id)
    {
        _context = new Crud();
        return _context.Find<Cliente>(id);
    }

    public bool? RemoverCliente(int id)
    {
        _context = new Crud();
        var clienteDto = _context.Find<Cliente>(id);
        if (clienteDto == null)
        {
            return false;
        }
        _context.Remove(clienteDto);
        _context.SaveChanges();
        
        return true;
    }

    public Cliente? AlterarCliente(int id, string nome, string email, string telefone)
    {
        _context = new Crud();
        var cliente = _context.Cliente.Find(id);
        if (cliente == null)
        {
            return null;
        }
        cliente.Nome = nome;
        cliente.Email = email;
        cliente.Telefone = telefone;
        
        _context.Update(cliente); // Não necessário, porém decidi manter por segurança
        _context.SaveChanges();
        
        return cliente;
    }
}