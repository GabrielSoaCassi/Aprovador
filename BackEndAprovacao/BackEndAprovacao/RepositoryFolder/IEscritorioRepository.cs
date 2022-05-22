using BackEndAprovacao.Models;
using System.Collections.Generic;

namespace BackEndAprovacao.RepositoryFolder
{
    public interface IEscritorioRepository : IRepository<Escritorio>
    {
        List<Escritorio> PesquisarTodos();
    }
}