using Eturnos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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

        public DbSet<Medico> Medicos { get; set; }


        public DbSet<MedicoEspecialidad> MedicosEspecialidades { get; set; }

        public DbSet<Turno> Turnos { get; set; }

        public DbSet<Login> Login { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidades");
                entidad.HasKey(e => e.Id);
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
            modelBuilder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medicos");
                entidad.HasKey(m => m.Id);
                entidad.Property(m => m.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(m => m.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(m => m.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(m => m.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
                entidad.Property(p => p.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);
                entidad.Property(p => p.HorarioAtencioHasta)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspeciliadad });


            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
                .WithMany(p => p.MedicoEspecialidad)
                .HasForeignKey(x => x.IdMedico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
                .WithMany(p=>p.MedicoEspecialidad)
                .HasForeignKey(x => x.IdEspeciliadad);

            modelBuilder.Entity<Turno>(entidad =>
            {
                entidad.ToTable("Turnos");

                entidad.HasKey(t=>t.Id);

                entidad.Property(p=>p.IdPaciente)
                 .IsRequired()
                 .IsUnicode(false);

                entidad.Property(m => m.IdMedico)
                 .IsRequired()
                 .IsUnicode(false);
                
                entidad.Property(t => t.FechaHoraInicio)
                     .IsRequired()
                     .IsUnicode(false);
                entidad.Property(t => t.FechaHoraFin)
                    .IsRequired()
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
                .WithMany(t => t.Turno)
                .HasForeignKey(t => t.IdPaciente);

            modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
                .WithMany(t => t.Turno)
                .HasForeignKey(t => t.IdMedico);

            modelBuilder.Entity<Login>(entidad =>
            {
                entidad.ToTable("Login");
                entidad.HasKey(l => l.LoginId);
                entidad.Property(l => l.Usuario)
                .IsRequired();
                entidad.Property(l => l.Password)
                .IsRequired();
            });
        }
    }
}
