using Moq;
using NUnit.Framework;
using Application.UseCases;
using Application.Interfaces;
using Application.Compartilhado;

namespace Tests.Application
{
    [TestFixture]
    public class ConfigurarBaseDadosUseCaseTests
    {
        [Test]
        public void AtualizarCaminhoBaseDados_DeveEncaminharValoresParaServico()
        {
            //arrange
            const string CaminhoFakeTeste = "a";
            const int LeiauteCodigoFakeTeste = 1000;

            var mockConfigService = new Mock<IConfigService>();
            var mockLeiauteService = new Mock<ICodigosLeiauteService>();

            var sut = new ConfiguradorBaseDadosUseCase(mockConfigService.Object, mockLeiauteService.Object);

            //act
            sut.AtualizarCaminhoBaseDados(LeiauteCodigoFakeTeste, CaminhoFakeTeste);

            //assert
            mockConfigService.Verify(v => v.TentarAtualizarCaminhoBaseDados(LeiauteCodigoFakeTeste, CaminhoFakeTeste), Times.Once);
        }
    }
}