using Microsoft.EntityFrameworkCore;
using PrevisaoDoTempoAPI.Models;

namespace PrevisaoDoTempoAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Chave> Chaves { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder.Entity<Chave>()
                .HasIndex(u => u.Texto)
                .IsUnique();

            modelBuilder.Entity<Chave>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Chaves)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Consultas)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
