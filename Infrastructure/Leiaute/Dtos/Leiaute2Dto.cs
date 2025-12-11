using System.Linq;
using System.Collections.Generic;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Infrastructure.Leiaute.Dtos
{
    internal class Leiaute2Dto
    {
        [LeiauteCodigo(2)]
        [ConfiguracaoCaminhoBaseDados("CaminhoBaseDadosLeiaute2")]

        [CodigoLinha(0)]
        internal class EmpresaDto
        {
            public string Cnpj { get; set; }
            public string Nome { get; set; }
            public string Telefone { get; set; }
            public List<DocumentoDto> Documentos { get; set; }
        }

        [CodigoLinha(1)]
        internal class DocumentoDto
        {
            public string Modelo { get; set; }
            public string Numero { get; set; }
            public decimal Valor => Itens.Sum(s => s.Valor);
            public List<ItemDto> Itens { get; set; }
        }

        [CodigoLinha(2)]
        internal class ItemDto
        {
            public int NumeroItem { get; set; }
            public string Descricao { get; set; }
            public decimal Valor { get; set; }
            public List<CategoriaDto> Categorias { get; set; }
        }

        [CodigoLinha(3)]
        internal class CategoriaDto
        {
            public int NumeroCategoria { get; set; }
            public string DescricaoCategoria { get; set; }
        }
    }
}