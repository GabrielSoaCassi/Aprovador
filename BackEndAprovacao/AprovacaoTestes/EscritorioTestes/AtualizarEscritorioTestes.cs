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
    public class AtualizarEscritorioTestes
    {
        [Fact]
        public void Atualizar_QuandoAtualizarForChamadoComParametrosCorretos_DeveAtualizarOEscritorioNoBancoDeDados()
        {
            //Arrange
            var escritorioDummy = new List<Escritorio>() { new Escritorio() { Id = 1, Nome = "Escritorio Pearson" } };
            var atualizarEscritorio = new Escritorio() { Id = 1, Nome = "Pearson Processos" };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao
                .Setup(escritorio => escritorio.Set<Escritorio>())
                .Returns(DbSetShared.GetQueryableMockDbSet(escritorioDummy));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            //Act
            var resultadoEscritorio = escritorioService.Atualizar(atualizarEscritorio);
            //Assert
            Assert.Equal(resultadoEscritorio.Nome, atualizarEscritorio.Nome);
        }

        [Fact]
        public void Atualizar_QuandoAtualizarForChamadoComIdIncorreto_DeveLancarUmaArgumentException()
        {
            //Arrange
            var escritorioDummy = new List<Escritorio>() { new Escritorio() { Id = 1, Nome = "Escritorio Pearson" } };
            var atualizarEscritorio = new Escritorio() { Nome = "Pearson Processos" };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(escritorio => escritorio.Set<Escritorio>()).Returns(DbSetShared.GetQueryableMockDbSet(escritorioDummy));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            var mensagemEsperada = "Id inválido ou nome do escritório nulo cheque os dados inseridos novamente";
            //Act
            var mensagemObtida = Assert.Throws<ArgumentException>(() =>
                escritorioService.Atualizar(atualizarEscritorio));
            //Assert
            Assert.Equal(mensagemEsperada, mensagemObtida.Message);
        }

        [Theory]
        [InlineData("")]
        public void Atualizar_QuandoAtualizarForChamadoComEscritorioComNomeIncorreto_DeveLancarUmaArgumentException(string nome)
        {
            //Arrange
            var escritorioDummy = new List<Escritorio>() { new Escritorio() { Id = 1, Nome = "Escritorio Pearson" } };
            var atualizarEscritorioNome = new Escritorio() { Nome = nome };
            var mockContextoAprovacao = new Mock<IAprovacaoContext>();
            mockContextoAprovacao.Setup(escritorio => escritorio.Set<Escritorio>()).Returns(DbSetShared.GetQueryableMockDbSet(escritorioDummy));
            var escritorioRepository = new EscritorioRepository(mockContextoAprovacao.Object);
            var escritorioService = new EscritorioService(escritorioRepository);
            var mensagemEsperada = "Id inválido ou nome do escritório nulo cheque os dados inseridos novamente";
            //Act
            var mensagemObtida = Assert.Throws<ArgumentException>(() => escritorioService.Atualizar(atualizarEscritorioNome));
            //Assert
            Assert.Equal(mensagemEsperada, mensagemObtida.Message);
        }
    }
}