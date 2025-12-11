using Moq;
using System;
using System.Linq;
using NUnit.Framework;
using Infrastructure.Leiaute;
using System.Collections.Generic;
using Infrastructure.Leiaute.Interfaces;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Tests.Infrastructure
{
    [TestFixture]
    public class AdaptadorInterfaceLeiauteTests
    {
        //arrange
        [LeiauteCodigo(99)]
        [ConfiguracaoCaminhoBaseDados("ChaveFake")]
        [CodigoLinha(0)]
        public class EmpresaDtoFake
        {
            public string Nome { get; set; }
            public List<DocumentoDtoFake> Documentos { get; set; }
        }

        [CodigoLinha(1)]
        public class DocumentoDtoFake
        {
            public string Numero { get; set; }
            public List<ItemDtoFake> Itens { get; set; }
        }

        [CodigoLinha(2)]
        public class ItemDtoFake
        {
            public string Descricao { get; set; }
        }

        [Test]
        public void Converter_DeveChamarJsonSourceComTipoInformado()
        {
            var jsonSource = new Mock<IJsonSource>();

            jsonSource.Setup(s => s.GetJsonObject(typeof(EmpresaDtoFake)))
                      .Returns(new EmpresaDtoFake[0]);

            var adaptador = new AdaptadorInterfaceLeiaute(jsonSource.Object);

            adaptador.TentarConverter(typeof(EmpresaDtoFake));

            jsonSource.Verify(s => s.GetJsonObject(typeof(EmpresaDtoFake)), Times.Once);
        }

        [Test]
        public void Converter_DeveConverterArvoreCompletaParaLinha()
        {
            //arrange
            var jsonSource = new Mock<IJsonSource>();

            jsonSource.Setup(s => s.GetJsonObject(typeof(EmpresaDtoFake)))
                .Returns(new[] {
                new EmpresaDtoFake
                    {
                        Nome = "Empresa X",
                        Documentos = new List<DocumentoDtoFake>
                        {
                            new DocumentoDtoFake
                            {
                                Numero = "123",
                                Itens = new List<ItemDtoFake>
                                {
                                    new ItemDtoFake { Descricao = "Produto A" }
                                }
                            }
                        }
                    }
                });

            var adaptador = new AdaptadorInterfaceLeiaute(jsonSource.Object);

            //act
            var resultado = adaptador.TentarConverter(typeof(EmpresaDtoFake));

            var empresa = resultado.First();
            var documento = empresa.Filhos.First();
            var item = documento.Filhos.First();

            //assert
            Assert.AreEqual("Empresa X", empresa.Dados["Nome"]);
            Assert.AreEqual("123", documento.Dados["Numero"]);
            Assert.AreEqual("Produto A", item.Dados["Descricao"]);
        }

        [Test]
        public void Converter_DeveLancarQuandoJsonSourceRetornarObjetoInvalido()
        {
            //arrange
            var jsonSource = new Mock<IJsonSource>();

            jsonSource.Setup(s => s.GetJsonObject(typeof(EmpresaDtoFake)))
                      .Returns(new object());

            var adaptador = new AdaptadorInterfaceLeiaute(jsonSource.Object);

            //act-assert
            Assert.Throws<Exception>(() =>
            {
                adaptador.TentarConverter(typeof(EmpresaDtoFake));
            });
        }
    }
}