using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using BackEndAprovacao.Services;
using Moq;
using System;
using Xunit;

namespace AprovacaoTestes.EscritorioTestes
{
    public class AdicionarEscritorioTestes
    {
        [Fact]
        public void QuandoParametrosValidos_DeveInserirNoBancoDeDados()
        {
            //Arrange
            var escritorioDummy = new Escritorio() { Id = 1, Nome = "Escritorio Pearson" };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(escritorio => escritorio.Set<Escritorio>().Add(It.IsAny<Escritorio>()));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            //Act
            escritorioService.Cadastrar(escritorioDummy);
            //Assert
            mockContextoAprovacao.Verify(aprovacao => aprovacao.Set<Escritorio>().Add(It.IsAny<Escritorio>()), Times.Once);
            mockContextoAprovacao.Verify(aprovacao => aprovacao.SaveChanges(), Times.Once);
        }

        [Theory]
        [InlineData("   ")]
        [InlineData("")]
        [InlineData("aa")]
        public void QuandoParametrosIncorretos_DeveRetornarUmArgumentException(string nome)
        {
            //Arrange
            var escritorioDummy = new Escritorio() { Id = 1, Nome = nome };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(escritorio => escritorio.Escritorios.Add(It.IsAny<Escritorio>()));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            var msgEsperada = "O nome do escritório está inválido";
            //Act
            var excecaoObtida = Assert
                .Throws<ArgumentException>(() => escritorioService.Cadastrar(escritorioDummy));
            //Assert
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}