using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using System.Linq;

namespace BackEndAprovacao.RepositoryFolder
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntidadeBase
    {
        private readonly IAprovacaoContext _aprovacaoContext;

        public Repository(IAprovacaoContext aprovacaoContext)
        {
            _aprovacaoContext = aprovacaoContext;
        }

        public TEntity Adicionar(TEntity entity)
        {
            _aprovacaoContext.Set<TEntity>().Add(entity);
            _aprovacaoContext.SaveChanges();
            return entity;
        }

        public TEntity Atualizar(TEntity entity)
        {
            _aprovacaoContext.Set<TEntity>().Update(entity);
            _aprovacaoContext.SaveChanges();
            return entity;
        }

        public void Deletar(int id)
        {
            var entityparaDeletar = Pesquisar(id);
            _aprovacaoContext.Set<TEntity>().Remove(entityparaDeletar);
            _aprovacaoContext.SaveChanges();
        }

        public TEntity Pesquisar(int id) =>
            _aprovacaoContext.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);
    }
}