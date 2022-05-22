using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.Repository;
using BackEndAprovacao.Services;
using Moq;
using System;
using Xunit;

namespace AprovacaoTestes.ProcessoTestes
{
    public class AdicionarProcessosTeste
    {
        [Fact]
        public void QuandoParametrosCorretos_DeveAdicionarAoBancoDeDados()
        {
            //Arrange
            var processoFake = new Processo()
            {
                Id = 1,
                NumeroDeProcesso = "01234567890123456789",
                ValorCausa = 300000,
                EscritorioId = 1,
                ReclamanteId = 1
            };
            var mockContexto = new Mock<IAprovacaoContext>();
            mockContexto.Setup(aprovacao => aprovacao.Set<Processo>().Add(It.IsAny<Processo>()));
            var processoRepository = new ProcessoRepository(mockContexto.Object);
            var processoService = new ProcessoService(processoRepository);
            //Act
            processoService.Cadastrar(processoFake);
            //Assert
            mockContexto.Verify(aprovacao => aprovacao.Set<Processo>().Add(It.IsAny<Processo>()), Times.Once);
            mockContexto.Verify(aprovacao => aprovacao.SaveChanges(), Times.Once);
        }

        [Theory]
        [InlineData("  ")]
        [InlineData("123               ")]
        [InlineData("012345678901234564455515")]
        public void QuandoParametrosIncorretos_DeveLancarArgumentException(string numero)
        {
            //Arrange
            var processoFake = new Processo()
            {
                Id = 1,
                NumeroDeProcesso = numero,
                ValorCausa = 300000,
                EscritorioId = 1,
                ReclamanteId = 1
            };
            var mockContexto = new Mock<IAprovacaoContext>();
            mockContexto.Setup(aprovacao => aprovacao.Set<Processo>().Add(It.IsAny<Processo>()));
            var processoRepository = new ProcessoRepository(mockContexto.Object);
            var processoService = new ProcessoService(processoRepository);
            var mensagemEsperada = "O número do processo está inconsistente, ou o valor está menor que R$30.000,00 verifique e tente novamente";
            //Act
            var mensagemObtida = Assert.Throws<ArgumentException>(() => processoService.Cadastrar(processoFake));
            //
            Assert.Equal(mensagemEsperada, mensagemObtida.Message);
        }
    }
}