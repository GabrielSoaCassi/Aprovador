using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using BackEndAprovacao.Services;
using Moq;
using OrganizerTestes;
using System;
using System.Collections.Generic;
using Xunit;

namespace AprovacaoTestes.ReclamanteTestes
{
    public class AtualizarReclamanteTeste
    {
        [Fact]
        public void QuandParametrosCorretos_DeveAtualizarOReclamanteNoBancoDeDados()
        {
            //Arrange
            var reclamanteDummy = new List<Reclamante>() { new Reclamante() { Id = 1, Nome = "ReclamanteNobre" } };
            var atualizarReclamante = new Reclamante() { Id = 1, Nome = "Reclamante Plebeu" };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao
                .Setup(aprovacao => aprovacao.Set<Reclamante>())
                .Returns(DbSetShared.GetQueryableMockDbSet(reclamanteDummy));
            var ReclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var ReclamanteService = new ReclamanteService(ReclamanteRepository);
            //Act
            var resultadoReclamante = ReclamanteService.Atualizar(atualizarReclamante);
            //Assert
            Assert.Equal(resultadoReclamante.Nome, atualizarReclamante.Nome);
        }

        [Fact]
        public void QuandoIdIncorreto_DeveLancarUmaArgumentException()
        {
            //Arrange
            var reclamanteDummy = new List<Reclamante>() { new Reclamante() { Id = 1, Nome = "Reclamante nobre" } };
            var atualizarReclamante = new Reclamante() { Nome = "Reclamante Junior" };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(aprovacao => aprovacao.Set<Reclamante>())
                .Returns(DbSetShared
                .GetQueryableMockDbSet(reclamanteDummy));
            var ReclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var ReclamanteService = new ReclamanteService(ReclamanteRepository);
            var mensagemEsperada = "Id inválido ou nome do reclamante nulo cheque os dados inseridos novamente";
            //Act
            var mensagemObtida = Assert.Throws<ArgumentException>(() =>
                ReclamanteService.Atualizar(atualizarReclamante));
            //Assert
            Assert.Equal(mensagemEsperada, mensagemObtida.Message);
        }

        [Theory]
        [InlineData("")]
        public void QuandoNomeIncorreto_DeveLancarUmaArgumentException(string nome)
        {
            //Arrange
            var reclamanteDummy = new List<Reclamante>() { new Reclamante() { Id = 1, Nome = "Reclamante Real" } };
            var atualizarReclamanteNome = new Reclamante() { Nome = nome };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(aprovacao => aprovacao.Set<Reclamante>()).Returns(DbSetShared.GetQueryableMockDbSet(reclamanteDummy));
            var reclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var reclamanteService = new ReclamanteService(reclamanteRepository);
            var mensagemEsperada = "Id inválido ou nome do reclamante nulo cheque os dados inseridos novamente";
            //Act
            var mensagemObtida = Assert.Throws<ArgumentException>(() =>
                reclamanteService.Atualizar(atualizarReclamanteNome));
            //Assert
            Assert.Equal(mensagemEsperada, mensagemObtida.Message);
        }
    }
}