using Microsoft.AspNetCore.Mvc;
using UsuarioChallenge.Data.Dtos;

namespace UsuarioChallenge.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase{

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto) {
            return Ok();
        }
    }
}
