using BackEndAprovacao.Context;
using BackEndAprovacao.Models;
using BackEndAprovacao.Repository;
using BackEndAprovacao.Services;
using Moq;
using OrganizerTestes;
using System;
using System.Collections.Generic;
using Xunit;

namespace AprovacaoTestes.ProcessoTestes
{
    public class AtualizarProcessoTeste
    {
        [Fact]
        public void QuandoParametrosCorreto_DeveAtualizarProcessoNoBancoDeDados()
        {
            //Arrange
            var processoFake = new List<Processo>(){new Processo()
            {
                Id = 1,
                NumeroDeProcesso = "01234567890123456789",
                ValorCausa = 300000,
                EscritorioId = 1,
                ReclamanteId = 1
            } };
            var processoAtualizacao = new Processo()
            {
                Id = 1,
                NumeroDeProcesso = "01234567890123456789",
                ValorCausa = 45000,
                EscritorioId = 1,
                ReclamanteId = 1
            };

            var mockContexto = new Mock<IAprovacaoContext>();
            mockContexto.Setup(aprovacao => aprovacao.Set<Processo>())
                .Returns(DbSetShared
                .GetQueryableMockDbSet(processoFake));
            var processoRepository = new ProcessoRepository(mockContexto.Object);
            var processoService = new ProcessoService(processoRepository);
            //Act
            var processoAtualizado = processoService.Atualizar(processoAtualizacao);
            //Assert
            Assert.Equal(processoAtualizado.ValorCausa, processoAtualizacao.ValorCausa);
        }

        [Fact]
        public void QuandoParametrosIcorreto_DeveLancarArgumentException()
        {
            //Arrange
            var processoFake = new List<Processo>(){new Processo()
            {
                Id = 1,
                NumeroDeProcesso = "01234567890123456789",
                ValorCausa = 300000,
                EscritorioId = 1,
                ReclamanteId = 1
            } };
            var processoAtualizacao = new Processo()
            {
                Id = 0,
                NumeroDeProcesso = "",
                ValorCausa = 45000,
                EscritorioId = 1,
                ReclamanteId = 1
            };
            var mockContexto = new Mock<IAprovacaoContext>();
                mockContexto.Setup(aprovacao => aprovacao.Set<Processo>())
                .Returns(DbSetShared
                .GetQueryableMockDbSet(processoFake));
            var processoRepository = new ProcessoRepository(mockContexto.Object);
            var processoService = new ProcessoService(processoRepository);
            var mensagemEsperada = "Número de processo inconsistente verifique e tente novamente";
            //Act
            var mensagemObtida = Assert.Throws<ArgumentException>(() => processoService.Atualizar(processoAtualizacao));
            //Assert
            Assert.Equal(mensagemEsperada, mensagemObtida.Message);
        }
    }
}