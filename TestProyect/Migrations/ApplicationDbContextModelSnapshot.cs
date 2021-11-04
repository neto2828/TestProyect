﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestProyect.Data;

namespace TestProyect.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("TestProyect.Models.Equipos", b =>
                {
                    b.Property<int>("IdEquipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaEquId")
                        .HasColumnType("int");

                    b.Property<int?>("EntrenadorEquiId")
                        .HasColumnType("int");

                    b.Property<string>("NombreEquipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipo");

                    b.HasIndex("CategoriaEquId");

                    b.HasIndex("EntrenadorEquiId");

                    b.ToTable("Equipos");
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

            modelBuilder.Entity("TestProyect.Models.Jugadores", b =>
                {
                    b.Property<int>("IdJugador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CalleJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CambioPwJugador")
                        .HasColumnType("bit");

                    b.Property<string>("CasaJugador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelularJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CiudadJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EquipoJugId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstaturaJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstatusJugId")
                        .HasColumnType("int");

                    b.Property<string>("MaternoJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatriculaJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NacimientoJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NacionalidadJugId")
                        .HasColumnType("int");

                    b.Property<string>("NoExtJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoIntJugador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaisJugId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaternoJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PesoJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PiernaJugador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PosicionJugId")
                        .HasColumnType("int");

                    b.Property<bool>("ValidacionJugador")
                        .HasColumnType("bit");

                    b.HasKey("IdJugador");

                    b.HasIndex("EquipoJugId");

                    b.HasIndex("EstatusJugId");

                    b.HasIndex("NacionalidadJugId");

                    b.HasIndex("PaisJugId");

                    b.HasIndex("PosicionJugId");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("TestProyect.Models.Paises", b =>
                {
                    b.Property<int>("IdPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClasePais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPais");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("TestProyect.Models.Posiciones", b =>
                {
                    b.Property<int>("IdPosicion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstatusPosId")
                        .HasColumnType("int");

                    b.Property<string>("NombrePosicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UbicacionPosicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPosicion");

                    b.HasIndex("EstatusPosId");

                    b.ToTable("Posiciones");
                });

            modelBuilder.Entity("TestProyect.Models.Utileros", b =>
                {
                    b.Property<int>("IdUtilero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdscripcionUtiId")
                        .HasColumnType("int");

                    b.Property<bool>("CambioPwUtilero")
                        .HasColumnType("bit");

                    b.Property<string>("CanchaUtilero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CasaUtilero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelularUtilero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailUtilero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstatusUtiId")
                        .HasColumnType("int");

                    b.Property<string>("MaternoUtilero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MatriculaUtilero")
                        .HasColumnType("int");

                    b.Property<string>("NombreUtilero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordUtilero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaternoUtilero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ValidacionUtilero")
                        .HasColumnType("bit");

                    b.HasKey("IdUtilero");

                    b.HasIndex("AdscripcionUtiId");

                    b.HasIndex("EstatusUtiId");

                    b.ToTable("Utileros");
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

            modelBuilder.Entity("TestProyect.Models.Equipos", b =>
                {
                    b.HasOne("TestProyect.Models.Categorias", "Categorias")
                        .WithMany()
                        .HasForeignKey("CategoriaEquId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProyect.Models.Entrenadores", "Entrenadores")
                        .WithMany()
                        .HasForeignKey("EntrenadorEquiId");

                    b.Navigation("Categorias");

                    b.Navigation("Entrenadores");
                });

            modelBuilder.Entity("TestProyect.Models.Jugadores", b =>
                {
                    b.HasOne("TestProyect.Models.Equipos", "Equipos")
                        .WithMany()
                        .HasForeignKey("EquipoJugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusJugId");

                    b.HasOne("TestProyect.Models.Paises", "Nacionalidad")
                        .WithMany()
                        .HasForeignKey("NacionalidadJugId");

                    b.HasOne("TestProyect.Models.Paises", "Paises")
                        .WithMany()
                        .HasForeignKey("PaisJugId");

                    b.HasOne("TestProyect.Models.Posiciones", "Posiciones")
                        .WithMany()
                        .HasForeignKey("PosicionJugId");

                    b.Navigation("Equipos");

                    b.Navigation("Estatus");

                    b.Navigation("Nacionalidad");

                    b.Navigation("Paises");

                    b.Navigation("Posiciones");
                });

            modelBuilder.Entity("TestProyect.Models.Posiciones", b =>
                {
                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusPosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
                });

            modelBuilder.Entity("TestProyect.Models.Utileros", b =>
                {
                    b.HasOne("TestProyect.Models.Adscripcion", "Adscripcion")
                        .WithMany()
                        .HasForeignKey("AdscripcionUtiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProyect.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusUtiId");

                    b.Navigation("Adscripcion");

                    b.Navigation("Estatus");
                });
#pragma warning restore 612, 618
        }
    }
}
