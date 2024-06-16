﻿// <auto-generated />
using System;
using Ecomerce.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecomerce.Api.Migrations
{
    [DbContext(typeof(EcomerceContext))]
    [Migration("20240616174430_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DepartamentoUsuario", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("DepartamentoId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("DepartamentoUsuario");
                });

            modelBuilder.Entity("Ecomerce.Data.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Celular")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.HasIndex("Telefone", "Celular");

                    b.ToTable("contatos");
                });

            modelBuilder.Entity("Ecomerce.Data.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Ecomerce.Data.EnderecoEntrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("NomeEndereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Numero")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CEP")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("EnderecosEntrega");
                });

            modelBuilder.Entity("Ecomerce.Data.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("DataCadastro")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Mae")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RG")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Sexo")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("SituacaoCadastro")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("CPF", "Nome");

                    b.HasIndex("CPF", "RG")
                        .IsUnique()
                        .HasFilter("[RG] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DepartamentoUsuario", b =>
                {
                    b.HasOne("Ecomerce.Data.Departamento", null)
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecomerce.Data.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecomerce.Data.Contato", b =>
                {
                    b.HasOne("Ecomerce.Data.Usuario", "Usuario")
                        .WithOne("Contato")
                        .HasForeignKey("Ecomerce.Data.Contato", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ecomerce.Data.EnderecoEntrega", b =>
                {
                    b.HasOne("Ecomerce.Data.Usuario", "Usuario")
                        .WithMany("EnderecoEntrega")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ecomerce.Data.Usuario", b =>
                {
                    b.Navigation("Contato");

                    b.Navigation("EnderecoEntrega");
                });
#pragma warning restore 612, 618
        }
    }
}
