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
    public class PesquisarReclamanteTeste
    {
        [Fact]
        public void PesquisarTodos_QuandoChamado_DeveRetornarTodosReclamantesDoBancoDeDados()
        {
            //Arrange
            var reclamantesEsperados = new List<Reclamante>() { };
            for (var i = 0; i < 5; i++)
            {
                var reclamanteAtual = new Reclamante() { Id = i, Nome = $"Reclamante do Futuro {i}" };
                reclamantesEsperados.Add(reclamanteAtual);
            }
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao
                .Setup(aprovacao => aprovacao.Reclamantes)
                .Returns(DbSetShared.GetQueryableMockDbSet(reclamantesEsperados));
            var reclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var reclamanteService = new ReclamanteService(reclamanteRepository);
            //Act
            var reclamantesRetornados = reclamanteService.PesquisarTodos();
            //Assert
            Assert.NotNull(reclamantesRetornados);
            Assert.Equal(reclamantesEsperados.Count, reclamantesRetornados.Count);
        }

        [Fact]
        public void Pesquisar_QuandoParametroCorreto_DeveRetornarReclamanteReferenteAoId()
        {
            var reclamantesDummy = new List<Reclamante>() { };
            for (var i = 0; i < 5; i++)
            {
                var reclamanteAtual = new Reclamante() { Id = i, Nome = $"Reclamante Do Futuro {i}" };
                reclamantesDummy.Add(reclamanteAtual);
            }
            var reclamanteEsperado = 1;
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(reclamante => reclamante.Set<Reclamante>())
                .Returns(DbSetShared.GetQueryableMockDbSet(reclamantesDummy));
            var reclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var reclamanteService = new ReclamanteService(reclamanteRepository);
            //Act
            var reclamanteRetornado = reclamanteService.Pesquisar(reclamanteEsperado);
            //Assert
            Assert.Equal(reclamanteEsperado, reclamanteRetornado.Id);
        }

        [Fact]
        public void Pesquisar_QuandoParametroIncorreto_DeveRetornarArgumentException()
        {
            var reclamantesDummy = new List<Reclamante>() { };
            for (var i = 0; i < 5; i++)
            {
                var reclamanteAtual = new Reclamante() { Id = i, Nome = $"Reclamante Do Futuro {i}" };
                reclamantesDummy.Add(reclamanteAtual);
            }
            var reclamanteErrado = 0;
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
                mockContextoAprovacao.Setup(reclamante => reclamante.Set<Reclamante>())
                .Returns(DbSetShared.GetQueryableMockDbSet(reclamantesDummy));
            var reclamanteRepository = new ReclamanteRepository(mockContextoAprovacao.Object);
            var reclamanteService = new ReclamanteService(reclamanteRepository);
            var msgEsperada = "o id está inválido verifique e tente novamente";
            //Act
            var excecaoObtida = Assert.Throws<ArgumentException>(
                () => reclamanteService.Pesquisar(reclamanteErrado));
            //Assert
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}