using Microsoft.EntityFrameworkCore;
using MottuApi.Models;
using System.Linq;

namespace MottuApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Moto> Motos => Set<Moto>();
        public DbSet<Patio> Patios => Set<Patio>();
        public DbSet<Movimentacao> Movimentacoes => Set<Movimentacao>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Moto>()
                .HasIndex(m => m.Placa)
                .IsUnique();

            modelBuilder.Entity<Patio>()
                .HasIndex(p => p.Nome)
                .IsUnique();

            modelBuilder.Entity<Patio>()
                .HasIndex(p => p.Localizacao)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Username)
                .IsUnique();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var boolProps = entityType.ClrType
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(bool));

                foreach (var prop in boolProps)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(prop.Name)
                        .HasConversion<int>();
                }
            }

            modelBuilder.HasSequence<int>("SEQ_PATIO").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("SEQ_MOTO").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("SEQ_MOVIMENTACAO").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("SEQ_USUARIO").StartsAt(1).IncrementsBy(1);

            modelBuilder.Entity<Patio>()
                .Property(p => p.Id)
                .HasDefaultValueSql("SEQ_PATIO.NEXTVAL");

            modelBuilder.Entity<Moto>()
                .Property(m => m.Id)
                .HasDefaultValueSql("SEQ_MOTO.NEXTVAL");

            modelBuilder.Entity<Movimentacao>()
                .Property(m => m.Id)
                .HasDefaultValueSql("SEQ_MOVIMENTACAO.NEXTVAL");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .HasDefaultValueSql("SEQ_USUARIO.NEXTVAL");
        }
    }
}