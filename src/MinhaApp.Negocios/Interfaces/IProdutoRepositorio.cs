using MinhaApp.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Interfaces
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid idFornecedor);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);

    }
}
