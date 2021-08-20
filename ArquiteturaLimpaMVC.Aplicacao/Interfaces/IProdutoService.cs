using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> TodosProdutosAsync();

        Task<ProdutoDTO> ProdutoPorIdAsync(int? id);

        Task CriarAsync(ProdutoDTO produtoDTO);

        Task AtualizarAsync(ProdutoDTO produtoDTO);

        Task RemoverAsync(int? id);
    }
}