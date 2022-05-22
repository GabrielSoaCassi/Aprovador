using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.RepositoryFolder;
using BackEndAprovacao.Services;
using Moq;
using OrganizerTestes;
using System;
using System.Collections.Generic;
using Xunit;

namespace AprovacaoTestes.EscritorioTestes
{
    public class PesquisarEscritorioTestes
    {
        [Fact]
        public void PesquisarTodos_QuandoChamado_DeveRetornarTodosEscritoriosDoBancoDeDados()
        {
            //Arrange
            var escritoriosEsperados = new List<Escritorio>() { };
            for (var i = 0; i < 5; i++)
            {
                var escritorioAtual = new Escritorio() { Id = i, Nome = "Associados.INC" };
                escritoriosEsperados.Add(escritorioAtual);
            }
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
                mockContextoAprovacao.Setup(aprovacao => aprovacao.Escritorios).Returns(DbSetShared.GetQueryableMockDbSet(escritoriosEsperados));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            //Act
            var quantidadeEscritorioRetornados = escritorioService.PesquisarTodos();
            //Assert
            Assert.NotNull(quantidadeEscritorioRetornados);
            Assert.Equal(escritoriosEsperados.Count, quantidadeEscritorioRetornados.Count);
        }

        [Fact]
        public void Pesquisar_QuandoChamadoComParametroCorreto_DeveRetornarEscritorioReferenteAoId()
        {
            var escritoriosDummy = new List<Escritorio>() { };
            for (var i = 0; i < 5; i++)
            {
                var escritorioAtual = new Escritorio() { Id = i, Nome = "Associados.INC" };
                escritoriosDummy.Add(escritorioAtual);
            }
            var escritorioEsperado = 1;
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
                mockContextoAprovacao.Setup(aprovacao => aprovacao.Set<Escritorio>()).Returns(DbSetShared.GetQueryableMockDbSet(escritoriosDummy));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            //Act
            var escritorioRetornado = escritorioService.Pesquisar(escritorioEsperado);
            //Assert
            Assert.Equal(escritorioEsperado, escritorioRetornado.Id);
        }

        [Fact]
        public void Pesquisar_QuandoChamadoComParametroIncorreto_DeveRetornarArgumentException()
        {
            var escritoriosDummy = new List<Escritorio>() { };
            for (var i = 0; i < 5; i++)
            {
                var escritorioAtual = new Escritorio() { Id = i, Nome = "Associados.INC" };
                escritoriosDummy.Add(escritorioAtual);
            }
            var escritorioErrado = 0;
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
                mockContextoAprovacao.Setup(escritorio => escritorio.Escritorios).Returns(DbSetShared.GetQueryableMockDbSet(escritoriosDummy));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            var msgEsperada = "O id está inválido verifique e tente novamente";
            //Act
            var excecaoObtida = Assert.Throws<ArgumentException>(() => escritorioService.Pesquisar(escritorioErrado));
            //Assert
            Assert.Equal(msgEsperada, excecaoObtida.Message);
        }
    }
}