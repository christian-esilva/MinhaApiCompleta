using Microsoft.EntityFrameworkCore;
using MinhaApp.Infraestrutura.Contexto;
using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApp.Infraestrutura.Repositorios
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(ContextoApp contexto) : base(contexto) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Contexto.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Contexto.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid idFornecedor)
        {
            return await Buscar(p => p.IdFornecedor == idFornecedor);
        }
    }
}
