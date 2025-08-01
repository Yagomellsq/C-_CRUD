using System.Security.Cryptography;
using System.Text;

namespace CRUD.Cryptography;

/*
 * Como testes de medidas de seguranças por criptografias, eu decidi utilizar o AES (Advanced Encryption Standard) ao invés do Hash.
 * Pois meus testes neste software incluem um read de ToString com acesso direto ao banco de dados, e essa criptografia é um bom exemplo
 * do que se deve ser feito para armazenar as senhas, ao mesmo tempo que sem quebrar as outras aplicações de testes como o Read do exemplo
 * do CRUD que foi inicialmente proposto.
 *
 * Meu próximo projeto terá a criptografia Hash envolvida!
 */

public static class Cryptography
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes
    private static readonly byte[] Iv = Encoding.UTF8.GetBytes("abcdefghijklmnop"); // 16 bytes

    public static string Criptografar(string texto)
    {
        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = Iv;
        
        var encryptor = aes.CreateEncryptor();
        var bytesTexto = Encoding.UTF8.GetBytes(texto);
        var bytesCriptografados = encryptor.TransformFinalBlock(bytesTexto, 0, bytesTexto.Length);
        
        return Convert.ToBase64String(bytesCriptografados);
    }

    public static string Descriptografar(string texto)
    {
        using var aes = Aes.Create();
        aes.Key = Key;
        aes.IV = Iv;

        var decryptor = aes.CreateDecryptor();
        var bytesCriptografados = Convert.FromBase64String(texto);
        var bytesTexto = decryptor.TransformFinalBlock(bytesCriptografados, 0, bytesCriptografados.Length);

        return Encoding.UTF8.GetString(bytesTexto);
    }
}