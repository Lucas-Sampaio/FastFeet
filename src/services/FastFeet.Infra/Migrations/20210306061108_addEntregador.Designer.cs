﻿// <auto-generated />
using System;
using FastFeet.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FastFeet.Infra.Migrations
{
    [DbContext(typeof(FastFeetContext))]
    [Migration("20210306061108_addEntregador")]
    partial class addEntregador
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FastFeet.Dominio.AggregatesModel.DestinatarioAggregate.Destinatario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Destinatarios");
                });

            modelBuilder.Entity("FastFeet.Dominio.AggregatesModel.EntregadorAggregate.Entregador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvatarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Entregadores");
                });

            modelBuilder.Entity("FastFeet.Dominio.AggregatesModel.DestinatarioAggregate.Destinatario", b =>
                {
                    b.OwnsOne("FastFeet.Dominio.AggregatesModel.DestinatarioAggregate.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("DestinatarioId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Cep")
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Cidade")
                                .IsUnicode(true)
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Complemento")
                                .IsUnicode(true)
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Estado")
                                .IsUnicode(true)
                                .HasColumnType("varchar(100)");

                            b1.Property<string>("Logradouro")
                                .HasMaxLength(250)
                                .IsUnicode(true)
                                .HasColumnType("varchar(250)");

                            b1.Property<string>("Numero")
                                .IsUnicode(true)
                                .HasColumnType("varchar(100)");

                            b1.HasKey("DestinatarioId");

                            b1.ToTable("Destinatarios");

                            b1.WithOwner()
                                .HasForeignKey("DestinatarioId");
                        });

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
