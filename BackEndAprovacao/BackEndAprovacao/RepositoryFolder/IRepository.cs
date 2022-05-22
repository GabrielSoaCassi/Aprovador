namespace BackEndAprovacao.RepositoryFolder
{
    public interface IRepository<TEntity>
    {
        TEntity Adicionar(TEntity entity);
        TEntity Atualizar(TEntity entity);
        TEntity Pesquisar(int id);
        void Deletar(int id);
    }
}