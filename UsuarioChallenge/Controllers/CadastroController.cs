using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuarioChallenge.Data.Dtos;
using UsuarioChallenge.Services;

namespace UsuarioChallenge.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase{
        private CadastroService _cadatroService;

        public CadastroController(CadastroService cadatroService) {
            _cadatroService = cadatroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto) {
            Result resultado = _cadatroService.CadastraUsuario(createDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok("Usuario cadastrado com sucesso!");
        }
    }
}
