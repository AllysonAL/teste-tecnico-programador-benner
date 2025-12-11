using Moq;
using System;
using NUnit.Framework;
using Application.UseCases;
using Application.Interfaces;
using Application.Formatters;
using Application.Compartilhado;

namespace Tests.Application
{
    [TestFixture]
    public class GerarArquivoUseCaseTests
    {
        [Test]
        public void CriarArquivoNoCaminhoInformado_DeveEncaminharCodigoParaServico()
        {
            const int CodigoLeiauteFake = 1000;

            //arrange
            var mockConfigService = new Mock<IConfigService>();
            var mockLeiauteService = new Mock<ILeiauteService>();
            var mockLinhaFormatter = new Mock<ILinhaFormatter>();
            var mockCodigosLeiauteService = new Mock<ICodigosLeiauteService>();

            var sut = new GeradorArquivoUseCase(mockLeiauteService.Object, mockConfigService.Object,
                mockCodigosLeiauteService.Object, mockLinhaFormatter.Object);

            //act - assert
            Assert.Throws<Exception>(() => sut.TentarCriarArquivoNoCaminhoInformado(CodigoLeiauteFake));
            mockLeiauteService.Verify(v => v.TentarObterLinhasLeiaute(CodigoLeiauteFake), Times.Once);
        }
    }
}