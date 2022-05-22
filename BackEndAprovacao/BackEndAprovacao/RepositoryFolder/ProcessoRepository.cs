using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using System.Collections.Generic;
using System.Linq;

namespace BackEndAprovacao.Repository
{
    public class ProcessoRepository : Repository<Processo>, IProcessoRepository
    {
        private readonly IAprovacaoContext _aprovacaoContext;

        public ProcessoRepository(IAprovacaoContext aprovacaoContext) : base(aprovacaoContext)
        {
            _aprovacaoContext = aprovacaoContext;
        }

        public List<Processo> PesquisarTodos()
        {
            var resultadoDoSelect = from processos in _aprovacaoContext.Processos
                            where processos.Ativo
                            select new Processo()
                            {
                                Id = processos.Id,
                                NumeroDeProcesso = processos.NumeroDeProcesso,
                                ValorCausa = processos.ValorCausa,
                                Escritorio = processos.Escritorio,
                                Reclamante = processos.Reclamante,
                                EstadoId = processos.EstadoId
                            };
            return resultadoDoSelect.ToList();
        }
    }
}