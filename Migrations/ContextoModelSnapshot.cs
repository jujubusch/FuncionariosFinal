﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFuncionarios.Models;

#nullable disable

namespace FuncionariosFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoFuncionarios.Models.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CargoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoCargo");

                    b.Property<int>("EscalaId")
                        .HasColumnType("int");

                    b.Property<string>("SalarioCargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SalarioCargo");

                    b.HasKey("Id");

                    b.HasIndex("EscalaId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("ProjetoFuncionarios.Models.Escala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EscalaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescricaoEscala")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DescricaoEscala");

                    b.Property<string>("HorarioEntrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HorarioEntrada");

                    b.Property<string>("HorarioSaida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HorarioSaida");

                    b.Property<string>("IntervaloRetorno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IntervaloRetorno");

                    b.Property<string>("IntervaloSaida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IntervaloSaida");

                    b.HasKey("Id");

                    b.ToTable("Escala");
                });

            modelBuilder.Entity("ProjetoFuncionarios.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FuncionarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeFuncionario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeFuncionario");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("ProjetoFuncionarios.Models.Ponto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PontoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Data")
                        .HasColumnType("float")
                        .HasColumnName("Data");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("HorarioEntrada");

                    b.Property<DateTime>("HorarioSaida")
                        .HasColumnType("datetime2")
                        .HasColumnName("HorarioSaida");

                    b.Property<DateTime>("SaidaAlmoco")
                        .HasColumnType("datetime2")
                        .HasColumnName("SaidaAlmoco");

                    b.Property<DateTime>("VoltaAlmoco")
                        .HasColumnType("datetime2")
                        .HasColumnName("VoltaAlmoco");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Ponto");
                });

            modelBuilder.Entity("ProjetoFuncionarios.Models.Cargo", b =>
                {
                    b.HasOne("ProjetoFuncionarios.Models.Escala", "Escala")
                        .WithMany()
                        .HasForeignKey("EscalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escala");
                });

            modelBuilder.Entity("ProjetoFuncionarios.Models.Funcionario", b =>
                {
                    b.HasOne("ProjetoFuncionarios.Models.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("ProjetoFuncionarios.Models.Ponto", b =>
                {
                    b.HasOne("ProjetoFuncionarios.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}
