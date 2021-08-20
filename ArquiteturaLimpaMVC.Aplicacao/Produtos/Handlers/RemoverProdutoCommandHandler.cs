using ArquiteturaLimpaMVC.Aplicacao.Produtos.Commands;
using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Handlers
{
    public class RemoverProdutoCommandHandler : IRequestHandler<RemoverProdutoCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public RemoverProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(RemoverProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ProdutoPorIdAsync(request.Id);

            if (produto is null)
                throw new ApplicationException("A entidade não foi encontrada!");

            return await _produtoRepository.RemoverAsync(produto);
        }
    }
}