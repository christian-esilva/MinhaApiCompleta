using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhaApp.API.ViewModels;
using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;

namespace MinhaApp.API.Controllers
{
    [Route("api/fornecedores")]
    [ApiController]
    public class FornecedorController : MainController
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IFornecedorServico _fornecedorServico;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio, IMapper mapper, IFornecedorServico fornecedorServico)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _fornecedorServico = fornecedorServico;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorViewModel>> ObterTodos()
        {
            var fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepositorio.ObterTodos());
            return fornecedores;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            var result = await _fornecedorServico.Adicionar(fornecedor);

            if (!result) return BadRequest();

            return Ok(fornecedor);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            var result = await _fornecedorServico.Atualizar(fornecedor);

            if (!result) return BadRequest();

            return Ok(fornecedor);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null) return NotFound();

            var result = await _fornecedorServico.Remover(id);

            if (!result) return BadRequest();

            return Ok(fornecedor);
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepositorio.ObterFornecedorProdutosEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepositorio.ObterFornecedorEndereco(id));
        }
    }
}