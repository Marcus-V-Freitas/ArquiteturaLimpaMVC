using ArquiteturaLimpaMVC.Dominio.Entidades;
using MediatR;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Commands
{
    public class RemoverProdutoCommand : IRequest<Produto>
    {
        public int Id { get; set; }

        public RemoverProdutoCommand(int id)
        {
            Id = id;
        }
    }
}