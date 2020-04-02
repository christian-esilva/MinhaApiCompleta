using MinhaApp.Negocios.Entidades;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Interfaces
{
    public interface IProdutoServico : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
