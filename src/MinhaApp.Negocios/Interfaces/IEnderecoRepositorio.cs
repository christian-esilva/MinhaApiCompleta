using MinhaApp.Negocios.Entidades;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Interfaces
{
    public interface IEnderecoRepositorio : IRepositorio<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid id);
    }
}
