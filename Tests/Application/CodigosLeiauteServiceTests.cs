using Moq;
using NUnit.Framework;
using Application.Interfaces;
using Application.Compartilhado;

namespace Tests.Application
{
    [TestFixture]
    public class CodigosLeiauteServiceTests
    {
        [Test]
        public void ObterCodigosLeiaute_DeveRetornarValoresDoService()
        {
            //arrange
            var mock = new Mock<ILeiauteService>();

            mock.Setup(x => x.TentarObterCodigosLeiaute())
                .Returns(new[] { 1, 2, 3 });

            var sut = new CodigosLeiauteService(mock.Object);

            //act
            var result = sut.ObterCodigosLeiaute();

            //assert
            Assert.That(result, Is.EqualTo(new[] { 1, 2, 3 }));
            mock.Verify(x => x.TentarObterCodigosLeiaute(), Times.Once);
        }


        [TestCase("1", true)]
        [TestCase("999999", false)]
        public void EhCodigoLeiauteValido_DeveFuncionar(string valor, bool esperado)
        {
            //arrange
            var mock = new Mock<ILeiauteService>();

            mock.Setup(x => x.TentarObterCodigosLeiaute())
                .Returns(new[] { 1, 2, 3 });

            var sut = new CodigosLeiauteService(mock.Object);

            //act
            var resultado = sut.EhCodigoLeiauteValido(valor);

            //assert
            Assert.That(resultado, Is.EqualTo(esperado));
            mock.Verify(x => x.TentarObterCodigosLeiaute(), Times.Once);
        }
    }
}