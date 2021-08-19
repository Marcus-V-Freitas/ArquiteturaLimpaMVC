using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using ArquiteturaLimpaMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext _context;

        public ProdutoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Produto> AtualizarAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> CriarAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> ProdutoPorIdAsync(int? id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> ProdutoPorIdCategoriaAsync(int? id)
        {
            return await _context.Produtos
                                 .Include(x => x.Categoria)
                                 .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Produto> RemoverAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> TodosProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }
    }
}
