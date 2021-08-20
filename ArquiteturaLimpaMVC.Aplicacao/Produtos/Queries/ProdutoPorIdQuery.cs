using ArquiteturaLimpaMVC.Dominio.Entidades;
using MediatR;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Queries
{
    public class ProdutoPorIdQuery : IRequest<Produto>
    {
        public int Id { get; set; }

        public ProdutoPorIdQuery(int id)
        {
            Id = id;
        }
    }
}