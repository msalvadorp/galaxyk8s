﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sol.Demo.ApiOpBanca.Contexto;

namespace Sol.Demo.ApiOpBanca.Migrations
{
    [DbContext(typeof(CuentasContext))]
    [Migration("20201212205219_SQLServer")]
    partial class SQLServer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sol.Demo.Comunes.DTO.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidoPaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            IdCliente = 1,
                            ApellidoMaterno = "Lopez",
                            ApellidoPaterno = "Guerra",
                            Nombres = "Juan",
                            NroDocumento = "12312312"
                        },
                        new
                        {
                            IdCliente = 2,
                            ApellidoMaterno = "Nieto",
                            ApellidoPaterno = "Salguero",
                            Nombres = "Pedro",
                            NroDocumento = "67676767"
                        },
                        new
                        {
                            IdCliente = 3,
                            ApellidoMaterno = "Gomez",
                            ApellidoPaterno = "Perez",
                            Nombres = "Maria",
                            NroDocumento = "44344344"
                        });
                });

            modelBuilder.Entity("Sol.Demo.Comunes.DTO.Cuenta", b =>
                {
                    b.Property<int>("IdCuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCuenta");

                    b.HasIndex("IdCliente");

                    b.ToTable("Cuenta");

                    b.HasData(
                        new
                        {
                            IdCuenta = 1,
                            IdCliente = 1,
                            Saldo = 120000m
                        },
                        new
                        {
                            IdCuenta = 2,
                            IdCliente = 3,
                            Saldo = 80000m
                        },
                        new
                        {
                            IdCuenta = 3,
                            IdCliente = 2,
                            Saldo = 660000m
                        });
                });

            modelBuilder.Entity("Sol.Demo.Comunes.DTO.Transaccion", b =>
                {
                    b.Property<int>("IdTransaccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaOperacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCuentaDestino")
                        .HasColumnType("int");

                    b.Property<int>("IdCuentaOrigen")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdTransaccion");

                    b.ToTable("Transaccion");
                });

            modelBuilder.Entity("Sol.Demo.Comunes.DTO.Cuenta", b =>
                {
                    b.HasOne("Sol.Demo.Comunes.DTO.Cliente", "Cliente")
                        .WithMany("Cuenta")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
