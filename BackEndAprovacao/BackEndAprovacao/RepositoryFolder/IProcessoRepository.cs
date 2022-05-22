using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using System.Collections.Generic;

namespace BackEndAprovacao.Repository
{
    public interface IProcessoRepository : IRepository<Processo>
    {
        List<Processo> PesquisarTodos();
    }
}