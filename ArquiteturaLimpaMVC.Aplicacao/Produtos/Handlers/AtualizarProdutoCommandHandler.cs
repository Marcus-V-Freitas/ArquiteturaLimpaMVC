using ArquiteturaLimpaMVC.Aplicacao.Produtos.Commands;
using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Handlers
{
    public class AtualizarProdutoCommandHandler : IRequestHandler<AtualizarProdutoCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AtualizarProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ProdutoPorIdAsync(request.Id);

            if (produto is null)
                throw new ApplicationException("A entidade não foi encontrada!");

            produto.Atualizar(request.Nome,
                              request.Descricao,
                              request.Preco,
                              request.Estoque,
                              request.Imagem,
                              request.CategoriaId);

            return await _produtoRepository.AtualizarAsync(produto);
        }
    }
}