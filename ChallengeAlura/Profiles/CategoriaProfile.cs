using AutoMapper;
using ChallengeAlura.Data.Dtos.Categorias;
using ChallengeAlura.Models;
using System.ComponentModel;

namespace ChallengeAlura.Profiles {
    public class CategoriaProfile : Profile{

        public CategoriaProfile() {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>()
                .ForMember(categoria => categoria.Videos, opt => opt
                .MapFrom(categoria => categoria.Videos.Select
                (v => new { v.Id, v.Titulo, v.Descricao, v.Url })));
        }
    }
}
