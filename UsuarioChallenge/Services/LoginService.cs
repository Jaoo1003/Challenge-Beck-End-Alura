using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioChallenge.Data.Request;

namespace UsuarioChallenge.Services {
    public class LoginService {

        private SignInManager<IdentityUser<int>> _signInMenager;

        public LoginService(SignInManager<IdentityUser<int>> signInMenager) {
            _signInMenager = signInMenager;
        }

        public Result Login(LoginRequest request) {
            var resultadoIdentity = _signInMenager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login falhou");
        }
    }
}
