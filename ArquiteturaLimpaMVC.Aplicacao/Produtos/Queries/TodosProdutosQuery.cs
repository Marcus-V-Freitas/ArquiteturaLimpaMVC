using ArquiteturaLimpaMVC.Dominio.Entidades;
using MediatR;
using System.Collections.Generic;

namespace ArquiteturaLimpaMVC.Aplicacao.Produtos.Queries
{
    public class TodosProdutosQuery : IRequest<IEnumerable<Produto>>
    {
    }
}