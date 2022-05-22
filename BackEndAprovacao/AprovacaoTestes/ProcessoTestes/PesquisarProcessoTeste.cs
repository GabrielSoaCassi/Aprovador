using BackEndAprovacao.Models;
using BackEndAprovacao.Repository;
using BackEndAprovacao.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace AprovacaoTestes.ProcessoTestes
{
    public class PesquisarProcessoTeste
    {
        [Fact]
        public void QuandoPesquisarTodos_DeveRetornarTodosProcessos()
        {
            //Arrange
            var processosFake = new List<Processo>()
            {
                new Processo()
                {
                    Id = 1,
                    NumeroDeProcesso = $"01234567890123456789",
                    ValorCausa = 300000,
                    Escritorio = new Escritorio(){Id = 1 , Nome = "Nome Válido"},
                    Reclamante = new Reclamante(){ Id = 1 ,Nome ="Nome Válido"}
                }
            };
            var processoRepository = new Mock<IProcessoRepository>();
            processoRepository.Setup(processo => processo.PesquisarTodos()).Returns(processosFake);
            var processoService = new ProcessoService(processoRepository.Object);
            //Act
            var processosPesquisados = processoService.PesquisarTodos();
            //Assert
            Assert.Single(processosPesquisados);
        }
    }
}