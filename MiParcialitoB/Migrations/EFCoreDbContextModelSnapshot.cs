﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MiParcialitoB.Migrations
{
    [DbContext(typeof(EFCoreDbContext))]
    partial class EFCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MiParcialitoB.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreCurso")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("MiParcialitoB.Models.Estudiante", b =>
                {
                    b.Property<int>("EstudianteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EstudianteId");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("MiParcialitoB.Models.Inscripcion", b =>
                {
                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.HasKey("EstudianteId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("MiParcialitoB.Models.Inscripcion", b =>
                {
                    b.HasOne("MiParcialitoB.Models.Curso", "Curso")
                        .WithMany("Inscripciones")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiParcialitoB.Models.Estudiante", "Estudiante")
                        .WithMany("Inscripciones")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("MiParcialitoB.Models.Curso", b =>
                {
                    b.Navigation("Inscripciones");
                });

            modelBuilder.Entity("MiParcialitoB.Models.Estudiante", b =>
                {
                    b.Navigation("Inscripciones");
                });
#pragma warning restore 612, 618
        }
    }
}
