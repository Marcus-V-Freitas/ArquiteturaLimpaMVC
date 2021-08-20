using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Aplicacao.Interfaces;
using ArquiteturaLimpaMVC.Dominio.Entidades;
using ArquiteturaLimpaMVC.Dominio.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Aplicacao.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task AtualizarAsync(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.AtualizarAsync(categoria);
        }

        public async Task<CategoriaDTO> CategoriaPorIdAsync(int? id)
        {
            var categoria = await _categoriaRepository.CategoriaPorIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task CriarAsync(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.CriarAsync(categoria);
        }

        public async Task RemoverAsync(int? id)
        {
            var categoria = await _categoriaRepository.CategoriaPorIdAsync(id);
            await _categoriaRepository.RemoverAsync(categoria);
        }

        public async Task<IEnumerable<CategoriaDTO>> TodasCategoriasAsync()
        {
            var categorias = await _categoriaRepository.TodasCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }
    }
}