﻿// <auto-generated />
using System;
using BarberShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarberShop.Data.Migrations
{
    [DbContext(typeof(ContextoBanco))]
    partial class ContextoBancoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BarberShop.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ClinteId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ProfissionalId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("BarberShop.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BarberShop.Models.ClienteProfissional", b =>
                {
                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProfissionalId", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("ClientesProfissionais");
                });

            modelBuilder.Entity("BarberShop.Models.Profissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ImagemURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Profissionais");
                });

            modelBuilder.Entity("BarberShop.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FimServiço")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("InicioServiço")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("BarberShop.Models.ServicoProfissional", b =>
                {
                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("char(36)");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.Property<Guid>("ServicoId1")
                        .HasColumnType("char(36)");

                    b.HasKey("ProfissionalId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("ServicoId1");

                    b.ToTable("ServicosProfissionais");
                });

            modelBuilder.Entity("BarberShop.Models.Agenda", b =>
                {
                    b.HasOne("BarberShop.Models.Cliente", "Cliente")
                        .WithMany("Agendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Profissional", "Profissional")
                        .WithMany("Agendas")
                        .HasForeignKey("ProfissionalId");

                    b.Navigation("Cliente");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("BarberShop.Models.ClienteProfissional", b =>
                {
                    b.HasOne("BarberShop.Models.Cliente", "Cliente")
                        .WithMany("ClientesProfissionais")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Profissional", "Profissional")
                        .WithMany("ClientesProfissionais")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("BarberShop.Models.Servico", b =>
                {
                    b.HasOne("BarberShop.Models.Profissional", "Profissional")
                        .WithMany("Servicos")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("BarberShop.Models.ServicoProfissional", b =>
                {
                    b.HasOne("BarberShop.Models.Profissional", "Profissional")
                        .WithMany("ServicosProfissionais")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Servico", null)
                        .WithMany("ServicosProfissionais")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberShop.Models.Cliente", "Servico")
                        .WithMany()
                        .HasForeignKey("ServicoId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profissional");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("BarberShop.Models.Cliente", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("ClientesProfissionais");
                });

            modelBuilder.Entity("BarberShop.Models.Profissional", b =>
                {
                    b.Navigation("Agendas");

                    b.Navigation("ClientesProfissionais");

                    b.Navigation("Servicos");

                    b.Navigation("ServicosProfissionais");
                });

            modelBuilder.Entity("BarberShop.Models.Servico", b =>
                {
                    b.Navigation("ServicosProfissionais");
                });
#pragma warning restore 612, 618
        }
    }
}
