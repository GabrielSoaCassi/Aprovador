using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using BackEndAprovacao.Services;
using Moq;
using System;
using Xunit;

namespace AprovacaoTestes.ReclamanteTestes
{
    public class AdicionarReclamanteTeste
    {
        [Fact]
        public void Adicionar_QuandoChamadoComParametrosValidos_DeveInserirNoBancoDeDados()
        {
            //Arrange
            var reclamanteFake = new Reclamante() { Id = 1, Nome = "O Reclamador do futuro" };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(reclamante => reclamante.Set<Reclamante>().Add(It.IsAny<Reclamante>()));
            var reclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var reclamanteService = new ReclamanteService(reclamanteRepository);
            //Act
            reclamanteService.Cadastrar(reclamanteFake);
            //Assert
            mockContextoAprovacao.Verify(aprovacao => aprovacao.Set<Reclamante>().Add(It.IsAny<Reclamante>()), Times.Once);
            mockContextoAprovacao.Verify(aprovacao => aprovacao.SaveChanges(), Times.Once);
        }

        [Theory]
        [InlineData("   ")]
        [InlineData("")]
        public void Adicionar_QuandoNomeIncorreto_DeveRetornarArgumentException(string nome)
        {
            //Arrange
            var reclamanteDummy = new Reclamante() { Id = 1, Nome = nome };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(reclamante => reclamante.Reclamantes.Add(It.IsAny<Reclamante>()));
            var reclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var reclamanteService = new ReclamanteService(reclamanteRepository);
            var msgEsperada = "O nome do reclamante está inválido";
            //Act
            var excecaoObtida = Assert
                .Throws<ArgumentException>(
                () => reclamanteService.Cadastrar(reclamanteDummy)
                );
            //Assert
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}