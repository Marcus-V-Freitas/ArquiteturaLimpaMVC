using ArquiteturaLimpaMVC.Aplicacao.Produtos.Queries;
using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Handlers
{
    public class ProdutoPorIdQueryHandler : IRequestHandler<ProdutoPorIdQuery, Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoPorIdQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(ProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.ProdutoPorIdAsync(request.Id);
        }
    }
}