using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioChallenge.Data.Request;
using UsuarioChallenge.Models;

namespace UsuarioChallenge.Services {
    public class LoginService {

        private SignInManager<IdentityUser<int>> _signInMenager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInMenager, TokenService tokenService) {
            _signInMenager = signInMenager;
            _tokenService = tokenService;
        }

        public Result Login(LoginRequest request) {
            var resultadoIdentity = _signInMenager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded) {
                IdentityUser<int> identityUser = _signInMenager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == request.UserName.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _signInMenager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }
    }
}
