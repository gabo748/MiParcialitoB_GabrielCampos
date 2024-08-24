using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using MiParcialitoB.Models;

public class EFCoreDbContext : DbContext
{
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }

    // Constructor sin parámetros para operaciones de diseño
    public EFCoreDbContext()
    {
    }

    public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inscripcion>()
            .HasKey(i => new { i.EstudianteId, i.CursoId });

        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.Estudiante)
            .WithMany(e => e.Inscripciones)
            .HasForeignKey(i => i.EstudianteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.Curso)
            .WithMany(c => c.Inscripciones)
            .HasForeignKey(i => i.CursoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
