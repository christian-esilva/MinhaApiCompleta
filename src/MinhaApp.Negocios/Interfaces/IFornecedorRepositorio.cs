using MinhaApp.Negocios.Entidades;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Interfaces
{
    public interface IFornecedorRepositorio : IRepositorio<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
