using Microsoft.EntityFrameworkCore;
using MinhaApp.Infraestrutura.Contexto;
using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Infraestrutura.Repositorios
{
    public class EnderecoRepositorio : Repositorio<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(ContextoApp contexto) : base(contexto) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid id)
        {
            return await Contexto.Enderecos.AsNoTracking().FirstOrDefaultAsync(f => f.IdFornecedor == id);
        }
    }
}
