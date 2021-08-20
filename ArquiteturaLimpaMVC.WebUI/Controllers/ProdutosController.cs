using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.WebUI.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        private readonly IWebHostEnvironment _environment;

        public ProdutosController(IProdutoService produtoService, ICategoriaService categoriaService, IWebHostEnvironment environment)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.TodosProdutosAsync();
            return View(produtos);
        }

        [HttpGet]
        public async Task<IActionResult> Criar()
        {
            ViewBag.Categorias = new SelectList(await _categoriaService.TodasCategoriasAsync(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.CriarAsync(produtoDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(produtoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id is null) return NotFound();

            var produtoDTO = await _produtoService.ProdutoPorIdAsync(id);

            if (produtoDTO is null) return NotFound();

            ViewBag.Categorias = new SelectList(await _categoriaService.TodasCategoriasAsync(), "Id", "Nome");
            return View(produtoDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProdutoDTO produtoDTO)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.AtualizarAsync(produtoDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(produtoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Remover(int? id)
        {
            if (id is null) return NotFound();
            var produtoDTO = await _produtoService.ProdutoPorIdAsync(id);
            if (produtoDTO is null) return NotFound();
            return View(produtoDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(), ActionName(nameof(Remover))]
        public async Task<IActionResult> ConfirmarRemocao(int? id)
        {
            await _produtoService.RemoverAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id is null) return NotFound();
            var produtoDTO = await _produtoService.ProdutoPorIdAsync(id);

            if (produtoDTO is null) return NotFound();

            var wwwRoot = _environment.WebRootPath;
            var imagem = Path.Combine(wwwRoot, "Imagens\\" + produtoDTO.Imagem);
            ViewBag.ImagemExiste = System.IO.File.Exists(imagem);
            return View(produtoDTO);
        }
    }
}