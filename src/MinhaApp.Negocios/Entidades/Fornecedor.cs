using MinhaApp.Negocios.Enums;
using System.Collections.Generic;

namespace MinhaApp.Negocios.Entidades
{
    public class Fornecedor : Entidade
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public ETipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
