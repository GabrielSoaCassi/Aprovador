using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAprovacao.RepositoryFolder
{
    public class EscritorioRepository : Repository<Escritorio>, IEscritorioRepository
    {
        private readonly IAprovacaoContext _aprovacaoContext;

        public EscritorioRepository(IAprovacaoContext aprovacaoContext) : base(aprovacaoContext)
        {
            _aprovacaoContext = aprovacaoContext;
        }

        public List<Escritorio> PesquisarTodos() =>
            (from escritorio in _aprovacaoContext.Escritorios
             select new Escritorio()
             {
                 Id = escritorio.Id,
                 Nome = escritorio.Nome
             }).ToList();
    }
}