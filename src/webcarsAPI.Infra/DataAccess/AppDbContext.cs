using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webcarsAPI.Dominio.Entidades;

namespace webcarAPI.Infra.DataAccess
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string,
                                                   IdentityUserClaim<string>, IdentityUserRole<string>,
                                                   IdentityUserLogin<string>, IdentityRoleClaim<string>,
                                                   IdentityUserToken<string>>
    {
        public DbSet<Veiculo> Veiculos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configure Identity tables by calling base.OnModelCreating
            base.OnModelCreating(builder);

            // Additional configuration for the Veiculo entity
            builder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.VeiculoId);
                entity.Property(e => e.Marca)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(e => e.Modelo)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(e => e.Ano)
                      .IsRequired();
                entity.Property(e => e.Placa)
                      .IsRequired()
                      .HasMaxLength(10);
                entity.Property(e => e.Cor)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(e => e.Chassi)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(e => e.Renavam)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(e => e.Combustivel)
                      .IsRequired()
                      .HasMaxLength(20);
                entity.Property(e => e.Quilometragem)
                      .IsRequired();
                entity.Property(e => e.Cidade)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(e => e.Telefone)
                      .IsRequired()
                      .HasMaxLength(15);
                entity.Property(e => e.Valor)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
                entity.Property(e => e.Imagem)
                      .HasMaxLength(100);

                // Configure the relationship with the IdentityUser.
                // Note: Although the foreign key property is named "UserId" in Veiculo,
                // it will correspond to the "Id" property on the AspNetUsers table.
                entity.HasOne<IdentityUser>()
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}