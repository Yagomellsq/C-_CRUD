using CRUD.Data;
using CRUD.Entity;

namespace CRUD.Control;

public class Control
{
    private Crud? _context;

    private Cliente? _cliente;

    public Cliente? AdicionarCliente(string nome, string email, string senha, string telefone)
    {
        _context = new Crud();
        _cliente = new Cliente
        {
            Nome = nome,
            Email = email,
            Senha = Cryptography.Cryptography.Criptografar(senha),
            Telefone = telefone
        };
        
        _context.Add(_cliente);
        _context.SaveChanges();
        
        return _cliente;
    }

    public Cliente? BuscarCliente(int id)
    {
        _context = new Crud();
        var clienteDto = _context.Find<Cliente>(id);

        if (clienteDto != null)
        {
            clienteDto.Senha = Cryptography.Cryptography.Descriptografar(clienteDto.Senha);
        }
        return clienteDto;
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

    public Cliente? AlterarCliente(int id, string nome, string email, string senha, string telefone)
    {
        _context = new Crud();
        var cliente = _context.Cliente.Find(id);
        if (cliente == null)
        {
            return null;
        }
        cliente.Nome = nome;
        cliente.Email = email;
        cliente.Senha = senha;
        cliente.Telefone = telefone;
        
        _context.Update(cliente); // Não necessário, porém decidi manter por segurança
        _context.SaveChanges();
        
        return cliente;
    }

    public bool VerificarLogin(string email, string senha)
    {
        _context = new Crud();
        var clienteDto = _context.Cliente.FirstOrDefault(c => c.Email == email && c.Senha == Cryptography.Cryptography.Criptografar(senha));
        if (clienteDto == null)
        {
            return false;
        }
        return clienteDto.Senha == Cryptography.Cryptography.Criptografar(senha) && clienteDto.Email == email;
    }
}