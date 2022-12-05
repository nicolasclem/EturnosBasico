using Eturnos.Models;
using Microsoft.EntityFrameworkCore;

namespace Eturnos.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {

        }

        public DbSet<Especialidad> Especialidades { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidades");
                entidad.HasKey(e=>e.Id);
                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Pacientes");
                entidad.HasKey(p => p.Id);
                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
                entidad.Property(p => p.Apellido)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

                entidad.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(p => p.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });
        }
    }
}
