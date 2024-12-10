using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaDeBarbeariaBack.Models;

namespace SistemadeBarbeariaBack.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Barbeiro> Barbeiros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servicos> Servicos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barbeiro>().HasKey(b => b.IdBarbeiro);
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);
            modelBuilder.Entity<Servicos>().HasKey(s => s.IdServico);
            modelBuilder.Entity<Agendamento>().HasKey(a => a.AgendamentoId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.cliente)
                .WithMany(c => c.agendamentosClientes)
                .HasForeignKey(a => a.ClienteId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.barbeiro)
                .WithMany(b => b.agendamentosBarbeiro)
                .HasForeignKey(a => a.BarbeiroId);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.servicos)
                .WithMany(s => s.agendamentosServicos)
                .HasForeignKey(a => a.ServicoId);

            modelBuilder.Entity<Servicos>()
           .Property(s => s.Preco)
           .HasColumnType("decimal(10,2)");

            // Seed Data para Barbeiros
            modelBuilder.Entity<Barbeiro>().HasData(
                new Barbeiro { IdBarbeiro = 1, NomeBarbeiro = "Carlos", TelefoneBarbeiro = "123456789", Especialidade = "Corte" },
                new Barbeiro { IdBarbeiro = 2, NomeBarbeiro = "João", TelefoneBarbeiro = "234567890", Especialidade = "Barba" },
                new Barbeiro { IdBarbeiro = 3, NomeBarbeiro = "Pedro", TelefoneBarbeiro = "345678901", Especialidade = "Coloração" },
                new Barbeiro { IdBarbeiro = 4, NomeBarbeiro = "Lucas", TelefoneBarbeiro = "456789012", Especialidade = "Alisamento" },
                new Barbeiro { IdBarbeiro = 5, NomeBarbeiro = "Rafael", TelefoneBarbeiro = "567890123", Especialidade = "Corte e Barba" }
            );

            // Seed Data para Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { IdCliente = 1, NomeCliente = "Ana", TelefoneCliente = "987654321" },
                new Cliente { IdCliente = 2, NomeCliente = "Bruno", TelefoneCliente = "876543210" },
                new Cliente { IdCliente = 3, NomeCliente = "Clara", TelefoneCliente = "765432109" },
                new Cliente { IdCliente = 4, NomeCliente = "Diego", TelefoneCliente = "654321098" },
                new Cliente { IdCliente = 5, NomeCliente = "Elisa", TelefoneCliente = "543210987" }
            );

            // Seed Data para Serviços
            modelBuilder.Entity<Servicos>().HasData(
                new Servicos { IdServico = 1, Descricao = "Corte Simples", Preco = 20.00m },
                new Servicos { IdServico = 2, Descricao = "Barba", Preco = 15.00m },
                new Servicos { IdServico = 3, Descricao = "Corte e Barba", Preco = 30.00m },
                new Servicos { IdServico = 4, Descricao = "Coloração", Preco = 50.00m },
                new Servicos { IdServico = 5, Descricao = "Alisamento", Preco = 80.00m }
            );

            // Seed Data para Agendamentos
            modelBuilder.Entity<Agendamento>().HasData(
                new Agendamento { AgendamentoId = 1, ClienteId = 1, BarbeiroId = 1, ServicoId = 1, HorarioData = DateTime.Now.AddDays(1) },
                new Agendamento { AgendamentoId = 2, ClienteId = 2, BarbeiroId = 2, ServicoId = 2, HorarioData = DateTime.Now.AddDays(2) },
                new Agendamento { AgendamentoId = 3, ClienteId = 3, BarbeiroId = 3, ServicoId = 3, HorarioData = DateTime.Now.AddDays(3) },
                new Agendamento { AgendamentoId = 4, ClienteId = 4, BarbeiroId = 4, ServicoId = 4, HorarioData = DateTime.Now.AddDays(4) },
                new Agendamento { AgendamentoId = 5, ClienteId = 5, BarbeiroId = 5, ServicoId = 5, HorarioData = DateTime.Now.AddDays(5) }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
