using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webcarsAPI.Dominio.Entidades;

namespace webcarsAPI.Infra.DataAccess
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Veiculos)
                .WithOne(v => v.Usuario);

            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Imagem)
                .HasColumnType("varchar(100)");
        }
    }
}