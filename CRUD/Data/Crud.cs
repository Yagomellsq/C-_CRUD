using CRUD.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data;

public class Crud : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;port=3306;database=crud;user=root;password=",
            new MySqlServerVersion(new Version(8, 0, 34))
        );
    }
}