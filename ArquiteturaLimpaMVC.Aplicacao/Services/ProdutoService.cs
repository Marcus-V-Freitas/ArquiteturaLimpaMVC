using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Aplicacao.Interfaces;
using ArquiteturaLimpaMVC.Aplicacao.Produtos.Commands;
using ArquiteturaLimpaMVC.Aplicacao.Produtos.Queries;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProdutoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AtualizarAsync(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<AtualizarProdutoCommand>(produtoDTO);
            await _mediator.Send(produto);
        }

        public async Task CriarAsync(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<CriarProdutoCommand>(produtoDTO);
            await _mediator.Send(produto);
        }

        public async Task<ProdutoDTO> ProdutoPorIdAsync(int? id)
        {
            var produto = await _mediator.Send(new ProdutoPorIdQuery(id.Value));
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task RemoverAsync(int? id)
        {
            await _mediator.Send(new RemoverProdutoCommand(id.Value));
        }

        public async Task<IEnumerable<ProdutoDTO>> TodosProdutosAsync()
        {
            var produtos = await _mediator.Send(new TodosProdutosQuery());
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }
    }
}