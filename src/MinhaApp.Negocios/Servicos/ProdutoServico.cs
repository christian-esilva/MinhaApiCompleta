using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Entidades.Validacoes;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Servicos
{
    public class ProdutoServico : BaseServico, IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio, INotificador notificador) : base(notificador)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return;

            await _produtoRepositorio.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidacao(), produto)) return;

            await _produtoRepositorio.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepositorio?.Dispose();
        }

    }
}
