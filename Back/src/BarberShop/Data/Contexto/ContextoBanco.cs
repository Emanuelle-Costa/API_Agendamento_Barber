using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class ContextoBanco : DbContext
    {
         public ContextoBanco(DbContextOptions<ContextoBanco> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<ClienteProfissional> ClientesProfissionais { get; set; }
        public DbSet<ServicoProfissional> ServicosProfissionais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteProfissional> ()
                .HasKey(CP=> new {CP.ProfissionalId, CP.ClienteId});

            modelBuilder.Entity<ServicoProfissional> ()
                .HasKey(CP=> new {CP.ProfissionalId, CP.ServicoId});

            modelBuilder.Entity<Profissional>()
                .HasMany(p => p.Agendas)
                .WithOne(ap => ap.Profissional)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Agendas)
                .WithOne(ac => ac.Cliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}