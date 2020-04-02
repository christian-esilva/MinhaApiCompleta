using System;

namespace MinhaApp.Negocios.Entidades
{
    public class Produto : Entidade
    {
        public Guid IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
