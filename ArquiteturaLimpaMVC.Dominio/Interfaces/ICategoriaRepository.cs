using ArquiteturaLimpaMVC.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Dominio.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> TodasCategoriasAsync();
        Task<Categoria> CategoriaPorIdAsync(int? id);
        Task<Categoria> CriarAsync(Categoria categoria);
        Task<Categoria> AtualizarAsync(Categoria categoria);
        Task<Categoria> RemoverAsync(Categoria categoria);
    }
}
