using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuarioChallenge.Services {
    public class LogoutService {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager) {
            _signInManager = signInManager;
        }

        public Result Logout() {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout falhou");
        }
    }
}
