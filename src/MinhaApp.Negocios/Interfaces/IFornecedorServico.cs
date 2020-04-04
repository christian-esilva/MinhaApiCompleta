using MinhaApp.Negocios.Entidades;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Interfaces
{
    public interface IFornecedorServico : IDisposable
    {
        Task<bool> Adicionar(Fornecedor fornecedor);
        Task<bool> Atualizar(Fornecedor fornecedor);
        Task<bool> Remover(Guid id);
        Task AtualizarEndereco(Endereco endereco);
    }
}
