using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.WebUI.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.TodasCategoriasAsync();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.CriarAsync(categoriaDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id is null) return NotFound();
            var categoriaDTO = await _categoriaService.CategoriaPorIdAsync(id);
            if (categoriaDTO is null) return NotFound();

            return View(categoriaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.AtualizarAsync(categoriaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int? id)
        {
            if (id is null) return NotFound();
            var categoriaDTO = await _categoriaService.CategoriaPorIdAsync(id);
            if (categoriaDTO is null) return NotFound();
            return View(categoriaDTO);
        }

        [HttpPost(), ActionName(nameof(Remover))]
        public async Task<IActionResult> ConfirmarRemocao(int? id)
        {
            await _categoriaService.RemoverAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id is null) return NotFound();
            var categoriaDTO = await _categoriaService.CategoriaPorIdAsync(id);
            if (categoriaDTO is null) return NotFound();
            return View(categoriaDTO);
        }
    }
}