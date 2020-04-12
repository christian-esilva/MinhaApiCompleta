using MinhaApp.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Interfaces
{
    public interface IFornecedorRepositorio : IRepositorio<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<IEnumerable<Fornecedor>> ObterFornecedorEndereco();
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
