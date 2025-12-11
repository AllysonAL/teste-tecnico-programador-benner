using System;
using NUnit.Framework;
using Infrastructure.Leiaute;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Tests.Infrastructure
{
    [TestFixture]
    public class AppConfigJsonSourceTests
    {
        //arrange
        [ConfiguracaoCaminhoBaseDados("ChaveFake")]
        public class DtoFake { public string Nome { get; set; } }
        public class DtoSemAtributo { }

        [Test]
        public void GetJsonObject_DeveLancarQuandoNaoTiverAtributo()
        {
            //arrange
            var sut = new AppConfigJsonSource(
                fileReader: _ => "",
                settingsReader: _ => ""
            );

            //act-assert
            Assert.Throws<Exception>(() =>
                sut.GetJsonObject(typeof(DtoSemAtributo))
            );
        }

        [Test]
        public void GetJsonObject_DeveLancarQuandoChaveNaoExistir()
        {
            //arrange
            var sut = new AppConfigJsonSource(
                fileReader: _ => "",
                settingsReader: key => null
            );

            //act-assert
            Assert.Throws<Exception>(() =>
                sut.GetJsonObject(typeof(DtoFake))
            );
        }

        [Test]
        public void GetJsonObject_DeveDesserializarJsonQuandoTudoValido()
        {
            //arrange
            var sut = new AppConfigJsonSource(
                fileReader: path => "[{\"nome\": \"Joao\"}]",
                settingsReader: key => "fakePath.json"
            );

            //act
            var resultado = sut.GetJsonObject(typeof(DtoFake));

            //assert
            Assert.IsInstanceOf(typeof(DtoFake[]), resultado);
            Assert.AreEqual("Joao", ((DtoFake[])resultado)[0].Nome);
        }
    }
}
