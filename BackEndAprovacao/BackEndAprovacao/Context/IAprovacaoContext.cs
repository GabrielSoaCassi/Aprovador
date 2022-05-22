using BackEndAprovacao.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndAprovacao.Context
{
    public interface IAprovacaoContext
    {
        int SaveChanges();
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
        public DbSet<Escritorio> Escritorios { get; set; }
        public DbSet<Reclamante> Reclamantes { get; set; }
        public DbSet<Processo> Processos { get; set; }
    }
}