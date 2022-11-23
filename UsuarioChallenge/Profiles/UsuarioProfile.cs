using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioChallenge.Data.Dtos;
using UsuarioChallenge.Models;

namespace UsuarioChallenge.Profiles {
    public class UsuarioProfile : Profile{

        public UsuarioProfile() {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
