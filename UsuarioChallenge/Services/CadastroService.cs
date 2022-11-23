using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioChallenge.Data.Dtos;
using UsuarioChallenge.Models;

namespace UsuarioChallenge.Services {
    public class CadastroService {

        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager) {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto) {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager.CreateAsync(identityUser, createDto.Password);
            if(resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuario");
        }
    }
}
