using ArquiteturaLimpaMVC.Aplicacao.Produtos.Commands;
using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Handlers
{
    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public CriarProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Nome,
                                      request.Descricao,
                                      request.Preco,
                                      request.Estoque,
                                      request.Imagem);

            if (produto is null)
                throw new ApplicationException("Erro ao criar a entidade!");

            produto.CategoriaId = request.CategoriaId;
            return await _produtoRepository.CriarAsync(produto);
        }
    }
}