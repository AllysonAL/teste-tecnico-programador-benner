using System.Linq;
using Domain.Entities;
using NUnit.Framework;
using Domain.Extensions;
using System.Collections.Generic;

namespace Tests.Domain
{
    [TestFixture]
    public class LinhaExtensionsTests
    {
        [Test]
        public void ObterContagemPorCodigo_DeveContarTodosOsCodigosRecursivamente()
        {
            //arrange
            var linhas = new List<Linha>
            {
                new Linha(1)
                {
                    Filhos =
                    {
                        new Linha(2),
                        new Linha(1)
                        {
                            Filhos = { new Linha(2) }
                        }
                    }
                }
            };

            //act
            var resultado = linhas.ObterContagemPorCodigo()
                .ToDictionary(c => c.Codigo, c => c.Quantidade);

            //assert
            Assert.AreEqual(2, resultado[1]);
            Assert.AreEqual(2, resultado[2]);
        }

        [Test]
        public void ContarTodasAsLinhas_DeveRetornarQuantidadeTotalDeLinhasRecursivamente()
        {
            //arrange
            var linhas = new List<Linha>
            {
                new Linha(1)
                {
                    Filhos =
                    {
                        new Linha(2),
                        new Linha(3)
                        {
                            Filhos = { new Linha(4) }
                        }
                    }
                }
            };

            //act
            var total = linhas.ContarTodasAsLinhas();

            //assert
            Assert.AreEqual(4, total);
        }
    }
}