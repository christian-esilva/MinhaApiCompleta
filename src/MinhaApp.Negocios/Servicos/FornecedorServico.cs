using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Entidades.Validacoes;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Servicos
{
    public class FornecedorServico : BaseServico, IFornecedorServico
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public FornecedorServico(IFornecedorRepositorio fornecedorRepositorio, IEnderecoRepositorio enderecoRepositorio,
            INotificador notificador) : base(notificador)
        {
            _enderecoRepositorio = enderecoRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidacao(), fornecedor) 
                || !ExecutarValidacao(new EnderecoValidacao(), fornecedor.Endereco)) return;

            if(_fornecedorRepositorio.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("O documento informado já está cadastrado"); 
                return;
            }

            await _fornecedorRepositorio.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidacao(), fornecedor)) return;

            if (_fornecedorRepositorio.Buscar(f => f.Documento == fornecedor.Documento && fornecedor.Id != fornecedor.Id).Result.Any())
            {
                Notificar("O documento informado já está cadastrado");
                return;
            }

            await _fornecedorRepositorio.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidacao(), endereco)) return;

            await _enderecoRepositorio.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            if (_fornecedorRepositorio.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            await _fornecedorRepositorio.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepositorio?.Dispose();
            _enderecoRepositorio?.Dispose();
        }
    }
}
