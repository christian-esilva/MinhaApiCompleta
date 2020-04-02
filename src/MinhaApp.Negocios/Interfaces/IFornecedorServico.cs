using MinhaApp.Negocios.Entidades;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Interfaces
{
    public interface IFornecedorServico : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);
        Task AtualizarEndereco(Endereco endereco);
    }
}
