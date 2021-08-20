using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> TodasCategoriasAsync();

        Task<CategoriaDTO> CategoriaPorIdAsync(int? id);

        Task CriarAsync(CategoriaDTO categoriaDTO);

        Task AtualizarAsync(CategoriaDTO categoriaDTO);

        Task RemoverAsync(int? id);
    }
}