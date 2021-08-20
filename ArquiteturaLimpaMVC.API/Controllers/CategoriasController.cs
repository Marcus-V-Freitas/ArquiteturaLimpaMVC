using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet(Name = nameof(TodasCategorias))]
        public async Task<IActionResult> TodasCategorias()
        {
            var categorias = await _categoriaService.TodasCategoriasAsync();

            if (categorias is null)
                return NotFound("As Categorias não foram encontradas!");

            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = nameof(CategoriaPorId))]
        public async Task<IActionResult> CategoriaPorId([FromRoute] int id)
        {
            var categoria = await _categoriaService.CategoriaPorIdAsync(id);
            if (categoria is null)
                return NotFound("A Categoria não foi encontrada!");

            return Ok(categoria);
        }

        [HttpPost(Name = nameof(CriarCategoria))]
        public async Task<IActionResult> CriarCategoria([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO is null)
                return BadRequest("Dado Inválido!");

            await _categoriaService.CriarAsync(categoriaDTO);

            return new CreatedAtRouteResult(nameof(CategoriaPorId), new { id = categoriaDTO.Id });
        }

        [HttpPut("{id:int}", Name = nameof(AtualizarCategoria))]
        public async Task<IActionResult> AtualizarCategoria([FromRoute] int id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
                return BadRequest();

            if (categoriaDTO is null)
                return BadRequest("");

            await _categoriaService.AtualizarAsync(categoriaDTO);
            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:int}", Name = nameof(RemoverCategoria))]
        public async Task<IActionResult> RemoverCategoria([FromRoute] int id)
        {
            var categoriaDTO = await _categoriaService.CategoriaPorIdAsync(id);
            if (categoriaDTO is null)
                return NotFound("Categoria não encontrado!");

            await _categoriaService.RemoverAsync(id);
            return Ok(categoriaDTO);
        }
    }
}