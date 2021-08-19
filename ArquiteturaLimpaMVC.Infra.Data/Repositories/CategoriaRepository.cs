using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using ArquiteturaLimpaMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationContext _context;

        public CategoriaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Categoria> AtualizarAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> CategoriaPorIdAsync(int? id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> CriarAsync(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> RemoverAsync(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<IEnumerable<Categoria>> TodasCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
