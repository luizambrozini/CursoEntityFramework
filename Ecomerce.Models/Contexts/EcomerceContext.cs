using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Data.Contexts
{
    public class EcomerceContext : DbContext
    {
        public EcomerceContext(DbContextOptions<EcomerceContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
