using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAprovacao.RepositoryFolder
{
    public class ReclamanteRepository : Repository<Reclamante>, IReclamanteRepository
    {
        private readonly IAprovacaoContext _aprovacaoContext;

        public ReclamanteRepository(IAprovacaoContext reclamante) : base(reclamante)
        {
            _aprovacaoContext = reclamante;
        }

        public List<Reclamante> PesquisarTodos() =>
            (from reclamante in _aprovacaoContext.Reclamantes
             select new Reclamante()
             {
                 Id = reclamante.Id,
                 Nome = reclamante.Nome
             }).ToList();
    }
}