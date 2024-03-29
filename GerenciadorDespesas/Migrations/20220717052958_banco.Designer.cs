﻿// <auto-generated />
using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciadorDespesas.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220717052958_banco")]
    partial class banco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("GerenciadorDespesas.Models.Despesas", b =>
                {
                    b.Property<int>("DespesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<int>("TipoDespesaId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("DespesaId");

                    b.HasIndex("MesId");

                    b.HasIndex("TipoDespesaId");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Meses", b =>
                {
                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MesId");

                    b.ToTable("Meses");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Salarios", b =>
                {
                    b.Property<int>("SalarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("SalarioId");

                    b.HasIndex("MesId")
                        .IsUnique();

                    b.ToTable("Salarios");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.TipoDespesas", b =>
                {
                    b.Property<int>("TipoDespesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoDespesaId");

                    b.ToTable("TipoDespesas");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Despesas", b =>
                {
                    b.HasOne("GerenciadorDespesas.Models.Meses", "Meses")
                        .WithMany("Despesas")
                        .HasForeignKey("MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciadorDespesas.Models.TipoDespesas", "TipoDespesas")
                        .WithMany("Despesas")
                        .HasForeignKey("TipoDespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meses");

                    b.Navigation("TipoDespesas");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Salarios", b =>
                {
                    b.HasOne("GerenciadorDespesas.Models.Meses", "Meses")
                        .WithOne("Salarios")
                        .HasForeignKey("GerenciadorDespesas.Models.Salarios", "MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meses");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.Meses", b =>
                {
                    b.Navigation("Despesas");

                    b.Navigation("Salarios");
                });

            modelBuilder.Entity("GerenciadorDespesas.Models.TipoDespesas", b =>
                {
                    b.Navigation("Despesas");
                });
#pragma warning restore 612, 618
        }
    }
}
