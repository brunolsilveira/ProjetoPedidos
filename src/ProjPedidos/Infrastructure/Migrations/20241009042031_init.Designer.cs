﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjPedidos.Infrastructure.Data;

#nullable disable

namespace ProjPedidos.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241009042031_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjPedidos.Domain.Entities.ItensPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItensPedido", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdPedido = 1,
                            IdProduto = 1,
                            Quantidade = 1
                        },
                        new
                        {
                            Id = 2,
                            IdPedido = 1,
                            IdProduto = 2,
                            Quantidade = 2
                        },
                        new
                        {
                            Id = 3,
                            IdPedido = 2,
                            IdProduto = 3,
                            Quantidade = 12
                        },
                        new
                        {
                            Id = 4,
                            IdPedido = 2,
                            IdProduto = 4,
                            Quantidade = 1
                        },
                        new
                        {
                            Id = 5,
                            IdPedido = 3,
                            IdProduto = 1,
                            Quantidade = 1
                        });
                });

            modelBuilder.Entity("ProjPedidos.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Pedido", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCriacao = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailCliente = "",
                            NomeCliente = "Cliente 1",
                            Pago = true
                        },
                        new
                        {
                            Id = 2,
                            DataCriacao = new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailCliente = "",
                            NomeCliente = "Cliente 2",
                            Pago = true
                        },
                        new
                        {
                            Id = 3,
                            DataCriacao = new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailCliente = "",
                            NomeCliente = "Cliente 3",
                            Pago = true
                        },
                        new
                        {
                            Id = 4,
                            DataCriacao = new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailCliente = "",
                            NomeCliente = "Cliente 4",
                            Pago = false
                        },
                        new
                        {
                            Id = 5,
                            DataCriacao = new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailCliente = "",
                            NomeCliente = "Cliente 5",
                            Pago = false
                        });
                });

            modelBuilder.Entity("ProjPedidos.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeProduto = "Produto 1",
                            Valor = 19.99m
                        },
                        new
                        {
                            Id = 2,
                            NomeProduto = "Produto 2",
                            Valor = 29.99m
                        },
                        new
                        {
                            Id = 3,
                            NomeProduto = "Produto 3",
                            Valor = 39.99m
                        },
                        new
                        {
                            Id = 4,
                            NomeProduto = "Produto 4",
                            Valor = 49.99m
                        },
                        new
                        {
                            Id = 5,
                            NomeProduto = "Produto 5",
                            Valor = 59.99m
                        });
                });

            modelBuilder.Entity("ProjPedidos.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ProjPedidos.Domain.Entities.ItensPedido", b =>
                {
                    b.HasOne("ProjPedidos.Domain.Entities.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjPedidos.Domain.Entities.Produto", "Produto")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ProjPedidos.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("ProjPedidos.Domain.Entities.Produto", b =>
                {
                    b.Navigation("ItensPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
