using Moq;
using NUnit.Framework;
using Application.UseCases;
using Application.Interfaces;

namespace Tests.Application
{
    [TestFixture]
    public class ConfigurarGerarArquivoUseCaseTests
    {
        [Test]
        public void AtualizarCaminhoGerarArquivo_DeveEncaminharValoresParaServico()
        {
            //arrange
            const string CaminhoFakeTeste = "a";

            var mock = new Mock<IConfigService>();
            var sut = new ConfiguradorGerarArquivoUseCase(mock.Object);

            //act
            sut.AtualizarCaminhoGerarArquivo(CaminhoFakeTeste);

            //assert
            mock.Verify(s => s.AtualizarCaminhoGerarArquivos(CaminhoFakeTeste), Times.Once);
        }
    }
}