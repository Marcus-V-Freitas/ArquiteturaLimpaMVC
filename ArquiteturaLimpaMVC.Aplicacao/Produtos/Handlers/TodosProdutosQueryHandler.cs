using ArquiteturaLimpaMVC.Aplicacao.Produtos.Queries;
using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Handlers
{
    public class TodosProdutosQueryHandler : IRequestHandler<TodosProdutosQuery, IEnumerable<Produto>>
    {
        private readonly IProdutoRepository _produtoRepository;

        public TodosProdutosQueryHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Produto>> Handle(TodosProdutosQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.TodosProdutosAsync();
        }
    }
}