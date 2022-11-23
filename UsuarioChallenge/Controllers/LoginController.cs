using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuarioChallenge.Data.Request;
using UsuarioChallenge.Services;

namespace UsuarioChallenge.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase{

        private LoginService _loginService;

        public LoginController(LoginService loginService) {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request) {
            Result resultado = _loginService.Login(request);
            if (resultado.IsFailed) return Unauthorized();
            return Ok(resultado.Successes.First());
        }
    }
}
