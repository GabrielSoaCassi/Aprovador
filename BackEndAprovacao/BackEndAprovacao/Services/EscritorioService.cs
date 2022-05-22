using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using System;
using System.Collections.Generic;

namespace BackEndAprovacao.Services
{
    public class EscritorioService : IServices<Escritorio>
    {
        private readonly IEscritorioRepository _escritorio;

        public EscritorioService(IEscritorioRepository escritorio)
        {
            _escritorio = escritorio;
        }

        public Escritorio Atualizar(Escritorio escritorio)
        {
            if (escritorio.Id > 0
                && !(string.IsNullOrEmpty(escritorio.Nome)
                && string.IsNullOrWhiteSpace(escritorio.Nome)))
                return _escritorio.Atualizar(escritorio);
            else
                throw new ArgumentException("Id inválido ou nome do escritório nulo cheque os dados inseridos novamente");
        }

        public Escritorio Cadastrar(Escritorio escritorio)
        {
            if (!string.IsNullOrEmpty(escritorio.Nome)
                && !string.IsNullOrWhiteSpace(escritorio.Nome)
                && escritorio.Nome.Length > 3)
            {
                return _escritorio.Adicionar(escritorio);
            }
            else
                throw new ArgumentException("O nome do escritório está inválido");
        }

        public Escritorio Pesquisar(int id)
        {
            if (id > 0)
            {
                return _escritorio.Pesquisar(id);
            }
            else
                throw new ArgumentException("O id está inválido verifique e tente novamente");
        }

        public List<Escritorio> PesquisarTodos() => _escritorio.PesquisarTodos();

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Digite um id válido");
            }
            _escritorio.Deletar(id);
        }
    }
}