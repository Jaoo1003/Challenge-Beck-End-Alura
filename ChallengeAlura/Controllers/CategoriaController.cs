using ChallengeAlura.Data.Dtos.Categorias;
using ChallengeAlura.Models;
using ChallengeAlura.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace ChallengeAlura.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase{

        private CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService) {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult BuscaCategoria() {
            List<ReadCategoriaDto> readDto = _categoriaService.BuscaCategoria();
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult BuscaCategoriaPorId(int id) {
            ReadCategoriaDto readDto = _categoriaService.BuscaCategoriaPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AdicionaCategoria(CreateCategoriaDto createDto) {
            ReadCategoriaDto readDto = _categoriaService.AdicionaCategoria(createDto);
            return CreatedAtAction(nameof(BuscaCategoriaPorId), new { id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, UpdateCategoriaDto updateDto) {
            Result resultado = _categoriaService.AtualizaCategoria(id, updateDto);
            if (resultado != null) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletaCategoria(int id) {
            Result resultado = _categoriaService.DeletaCategoria(id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
