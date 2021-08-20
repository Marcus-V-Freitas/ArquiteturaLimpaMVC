using ArquiteturaLimpaMVC.Dominio.Entidades;
using MediatR;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Commands
{
    public abstract class ProdutoCommand : IRequest<Produto>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Imagem { get; set; }
        public int CategoriaId { get; set; }
    }
}