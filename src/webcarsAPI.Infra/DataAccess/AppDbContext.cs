
using Microsoft.EntityFrameworkCore;
using webcarsAPI.Dominio.Entidades;
namespace webcarsAPI.Infra.DataAccess {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        
        public DbSet<BlackListTokens> BlackListTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Veiculos)
                .WithOne(v => v.Usuario);

            modelBuilder.Entity<Veiculo>()
                .Property(v => v.Imagem)
                .HasColumnType("string");
        }


    }
}