using ArquiteturaLimpaMVC.Aplicacao.DTOs;
using ArquiteturaLimpaMVC.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet(Name = nameof(TodosProdutos))]
        public async Task<IActionResult> TodosProdutos()
        {
            var produtos = await _produtoService.TodosProdutosAsync();

            if (produtos is null)
                return NotFound("Os produtos não foram encontrados!");

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = nameof(ProdutoPorId))]
        public async Task<IActionResult> ProdutoPorId([FromRoute] int id)
        {
            var produto = await _produtoService.ProdutoPorIdAsync(id);
            if (produto is null)
                return NotFound("O produto não foi encontrado!");

            return Ok(produto);
        }

        [HttpPost(Name = nameof(CriarProduto))]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO is null)
                return BadRequest("Dado Inválido!");

            await _produtoService.CriarAsync(produtoDTO);

            return new CreatedAtRouteResult(nameof(ProdutoPorId), new { id = produtoDTO.Id });
        }

        [HttpPut("{id:int}", Name = nameof(AtualizarProduto))]
        public async Task<IActionResult> AtualizarProduto([FromRoute] int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
                return BadRequest();

            if (produtoDTO is null)
                return BadRequest("");

            await _produtoService.AtualizarAsync(produtoDTO);
            return Ok(produtoDTO);
        }

        [HttpDelete("{id:int}", Name = nameof(RemoverProduto))]
        public async Task<IActionResult> RemoverProduto([FromRoute] int id)
        {
            var produtoDTO = await _produtoService.ProdutoPorIdAsync(id);
            if (produtoDTO is null)
                return NotFound("Produto não encontrado!");

            await _produtoService.RemoverAsync(id);
            return Ok(produtoDTO);
        }
    }
}