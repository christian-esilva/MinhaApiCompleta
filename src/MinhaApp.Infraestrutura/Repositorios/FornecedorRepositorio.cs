using Microsoft.EntityFrameworkCore;
using MinhaApp.Infraestrutura.Contexto;
using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Infraestrutura.Repositorios
{
    public class FornecedorRepositorio : Repositorio<Fornecedor>, IFornecedorRepositorio
    {
        public FornecedorRepositorio(ContextoApp contexto) : base(contexto) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Contexto.Fornecedores.AsNoTracking().Include(e => e.Endereco).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Contexto.Fornecedores.AsNoTracking()
                .Include(e => e.Produtos)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
