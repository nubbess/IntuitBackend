using IntuitChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace IntuitChallenge.Data
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options)
        {

        }
        //declaro la tabla clientes;
        public DbSet<Cliente> Clientes { get; set; }
    }
}
