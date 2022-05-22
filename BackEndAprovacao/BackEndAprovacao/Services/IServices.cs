using System.Collections.Generic;

namespace BackEndAprovacao.Services
{
    public interface IServices<T>
    {
        T Cadastrar(T opt);
        void Remover(int id);
        T Atualizar(T opt);
        T Pesquisar(int id);
        List<T> PesquisarTodos();
    }
}