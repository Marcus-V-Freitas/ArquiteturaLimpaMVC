using ArquiteturaLimpaMVC.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Dominio.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> TodosProdutosAsync();

        Task<Produto> ProdutoPorIdAsync(int? id);

        Task<Produto> CriarAsync(Produto produto);

        Task<Produto> AtualizarAsync(Produto produto);

        Task<Produto> RemoverAsync(Produto produto);
    }
}