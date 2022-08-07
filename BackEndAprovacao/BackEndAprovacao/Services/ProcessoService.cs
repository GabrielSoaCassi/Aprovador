using BackEndAprovacao.Models;
using BackEndAprovacao.Repository;
using System;
using System.Collections.Generic;

namespace BackEndAprovacao.Services
{
    public class ProcessoService : IServices<Processo>
    {
        private readonly IProcessoRepository _processo;

        public ProcessoService(IProcessoRepository processo)
        {
            _processo = processo;
        }

        public Processo Atualizar(Processo processo)
        {
            if (processo.Id > 0
                && !(string.IsNullOrEmpty(processo.NumeroDeProcesso)
                && !(string.IsNullOrWhiteSpace(processo.NumeroDeProcesso))))
                return _processo.Atualizar(processo);
            else
                throw new ArgumentException("Número de processo inconsistente verifique e tente novamente");
        }

        public Processo Cadastrar(Processo processo)
        {   
            if (!string.IsNullOrEmpty(processo.NumeroDeProcesso) &&
                !string.IsNullOrWhiteSpace(processo.NumeroDeProcesso) &&
                processo.NumeroDeProcesso.Length == 20 && processo.ValorCausa > 30000)
            {
                processo.Ativo = true;
                return _processo.Adicionar(processo);
            }
            else
                throw new ArgumentException("O número do processo está inconsistente, ou o valor está menor que R$30.000,00 verifique e tente novamente");
        }

        public Processo Pesquisar(int id)
        {
            if (id > 0)
                return _processo.Pesquisar(id);
            else
                throw new ArgumentException("o id está inválido verifique e tente novamente");
        }

        public List<Processo> PesquisarTodos() => _processo.PesquisarTodos();

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("o id está inválido");
            }
            _processo.Deletar(id);
        }
    }
}