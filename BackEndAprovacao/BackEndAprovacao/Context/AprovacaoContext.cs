using BackEndAprovacao.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAprovacao.Context
{
    public class AprovacaoContext : DbContext, IAprovacaoContext
    {
        public DbSet<Escritorio> Escritorios { get; set; }
        public DbSet<Reclamante> Reclamantes { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public AprovacaoContext(DbContextOptions<AprovacaoContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
        }
    }
}