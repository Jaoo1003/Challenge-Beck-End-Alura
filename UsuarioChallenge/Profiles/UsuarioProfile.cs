using AutoMapper;
using UsuarioChallenge.Data.Dtos;
using UsuarioChallenge.Models;

namespace UsuarioChallenge.Profiles {
    public class UsuarioProfile : Profile{

        public UsuarioProfile() {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
