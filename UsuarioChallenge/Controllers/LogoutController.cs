using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioChallenge.Services;

namespace UsuarioChallenge.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase{

        private LogoutService _logoutService;

        public LogoutController(LogoutService logoutService) {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout() {
            Result resultado = _logoutService.Logout();
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok();
        }
    }
}