using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using System;
using System.Collections.Generic;

namespace BackEndAprovacao.Services
{
    public class ReclamanteService : IServices<Reclamante>
    {
        private readonly IReclamanteRepository _reclamante;

        public ReclamanteService(IReclamanteRepository reclamante)
        {
            _reclamante = reclamante;
        }

        public Reclamante Atualizar(Reclamante reclamante)
        {
            if (reclamante.Id > 0
                && !(string.IsNullOrEmpty(reclamante.Nome)
                && string.IsNullOrWhiteSpace(reclamante.Nome)))
            {
                return _reclamante.Atualizar(reclamante);
            }
            else
                throw new ArgumentException("Id inválido ou nome do reclamante nulo cheque os dados inseridos novamente");
        }

        public Reclamante Cadastrar(Reclamante reclamante)
        {
            if (!string.IsNullOrEmpty(reclamante.Nome) && !string.IsNullOrWhiteSpace(reclamante.Nome))
            {
                return _reclamante.Adicionar(reclamante);
            }
            else
                throw new ArgumentException("O nome do reclamante está inválido");
        }

        public Reclamante Pesquisar(int id)
        {
            if (id > 0)
            {
                return _reclamante.Pesquisar(id);
            }
            else
                throw new ArgumentException("o id está inválido verifique e tente novamente");
        }

        public List<Reclamante> PesquisarTodos() => _reclamante.PesquisarTodos();

        public void Remover(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Digite um id válido");
            }
            _reclamante.Deletar(id);
        }
    }
}