﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestProyect.Data;

namespace TestProyect.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211024104949_Base")]
    partial class Base
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestProyect.Models.Administrativos", b =>
                {
                    b.Property<int>("IdAdministrativos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdscripcionAdminId")
                        .HasColumnType("int");

                    b.Property<bool>("CambioPwAdministrativo")
                        .HasColumnType("bit");

                    b.Property<string>("CasaAdministrativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelularAdministrativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdministrativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdEstatus")
                        .HasColumnType("int");

                    b.Property<string>("MaternoAdministrativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatriculaAdministrativo")
                        .HasColumnType("int");

                    b.Property<string>("NombreAdministrativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordAdministrativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaternoAdministrativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ValidacionAdministrativo")
                        .HasColumnType("bit");

                    b.HasKey("IdAdministrativos");

                    b.HasIndex("AdscripcionAdminId");

                    b.HasIndex("IdEstatus");

                    b.ToTable("Administrativos");
                });

            modelBuilder.Entity("TestProyect.Models.Adscripcion", b =>
                {
                    b.Property<int>("IdAdscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstatusId")
                        .HasColumnType("int");

                    b.Property<string>("NombreAdscripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAdscripcion");

                    b.HasIndex("EstatusId");

                    b.ToTable("Adscripcion");
                });

            modelBuilder.Entity("TestProyect.Models.Canchas", b =>
                {
                    b.Property<int>("IdCancha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstatusCanchaId")
                        .HasColumnType("int");

                    b.Property<string>("LatitudCancha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongitudCancha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCancha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoligonoCancha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCancha");

                    b.HasIndex("EstatusCanchaId");

                    b.ToTable("Canchas");
                });

            modelBuilder.Entity("TestProyect.Models.Categorias", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstatusCatId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.HasIndex("EstatusCatId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("TestProyect.Models.Entrenadores", b =>
                {
                    b.Property<int>("IdEntrenador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdscripcionEntId")
                        .HasColumnType("int");

                    b.Property<bool>("CambioPwEntrenador")
                        .HasColumnType("bit");

                    b.Property<string>("CasaEntrenador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoriaEntrenador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelularEntrenador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailEntrenador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstatusEntId")
                        .HasColumnType("int");

                    b.Property<string>("MaternoEntrenador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatriculaEntrenador")
                        .HasColumnType("int");

                    b.Property<string>("NombreEntrenador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordEntrenador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaternoEntrenador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ValidacionEntrenador")
                        .HasColumnType("bit");

                    b.HasKey("IdEntrenador");

                    b.HasIndex("AdscripcionEntId");

                    b.HasIndex("EstatusEntId");

                    b.ToTable("Entrenadores");
                });

            modelBuilder.Entity("TestProyect.Models.Estatus", b =>
                {
                    b.Property<int>("IdEstatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreEstatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstatus");

                    b.ToTable("Estatus");
                });

            modelBuilder.Entity("TestProyect.Models.Administrativos", b =>
                {
                    b.HasOne("TestProyect.Models.Adscripcion", "Adscripcion")
                        .WithMany()
                        .HasForeignKey("AdscripcionAdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("IdEstatus");

                    b.Navigation("Adscripcion");

                    b.Navigation("Estatus");
                });

            modelBuilder.Entity("TestProyect.Models.Adscripcion", b =>
                {
                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
                });

            modelBuilder.Entity("TestProyect.Models.Canchas", b =>
                {
                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusCanchaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
                });

            modelBuilder.Entity("TestProyect.Models.Categorias", b =>
                {
                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusCatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
                });

            modelBuilder.Entity("TestProyect.Models.Entrenadores", b =>
                {
                    b.HasOne("TestProyect.Models.Adscripcion", "Adscripcion")
                        .WithMany()
                        .HasForeignKey("AdscripcionEntId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusEntId");

                    b.Navigation("Adscripcion");

                    b.Navigation("Estatus");
                });
#pragma warning restore 612, 618
        }
    }
}