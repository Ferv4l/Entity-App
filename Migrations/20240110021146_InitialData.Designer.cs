﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20240110021146_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("4d67fc4f-3436-4140-b998-477de313808c"),
                            Nombre = "Actividades Pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("b35ae885-e17a-40ca-9de3-8b4c1a7bb2d6"),
                            Nombre = "Actividades Personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("webapi.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime");

                    b.Property<string>("PrioridadTarea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("4d67fc4f-3436-4140-b998-477de313832c"),
                            CategoriaId = new Guid("b35ae885-e17a-40ca-9de3-8b4c1a7bb2d6"),
                            FechaCreacion = new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(684),
                            FechaModificacion = new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(788),
                            PrioridadTarea = "Baja",
                            Titulo = "Cosas personales"
                        },
                        new
                        {
                            TareaId = new Guid("4d67fc4f-3436-4140-b998-477de313833c"),
                            CategoriaId = new Guid("4d67fc4f-3436-4140-b998-477de313808c"),
                            FechaCreacion = new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(800),
                            FechaModificacion = new DateTime(2024, 1, 9, 23, 11, 46, 742, DateTimeKind.Local).AddTicks(801),
                            PrioridadTarea = "Media",
                            Titulo = "Pago de servicios publicos"
                        });
                });

            modelBuilder.Entity("webapi.Models.Tarea", b =>
                {
                    b.HasOne("webapi.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("webapi.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
