using BackEndAprovacao.Models;
using System.Collections.Generic;

namespace BackEndAprovacao.RepositoryFolder
{
    public interface IReclamanteRepository : IRepository<Reclamante>
    {
        List<Reclamante> PesquisarTodos();
    }
}