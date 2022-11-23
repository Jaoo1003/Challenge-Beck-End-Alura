using AutoMapper;
using ChallengeAlura.Data;
using ChallengeAlura.Data.Dtos.Categorias;
using ChallengeAlura.Models;
using FluentResults;
using Microsoft.AspNetCore.Connections.Features;

namespace ChallengeAlura.Services {
    public class CategoriaService {

        private VideoDbContext _context;
        private IMapper _mapper;

        public CategoriaService(VideoDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadCategoriaDto> BuscaCategoria() {
            List<Categoria> categoria = _context.Categorias.ToList();
            if (categoria != null) {
                List<ReadCategoriaDto> readDto = _mapper.Map<List<ReadCategoriaDto>>(categoria);
                return readDto;
            }
            return null;
        }

        public ReadCategoriaDto BuscaCategoriaPorId(int id) {
            Categoria categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria != null) {
                ReadCategoriaDto readDto = _mapper.Map<ReadCategoriaDto>(categoria);
                return readDto;
            }
            return null;
        }

        public ReadCategoriaDto AdicionaCategoria(CreateCategoriaDto createDto) {
            Categoria categoria = _mapper.Map<Categoria>(createDto);
            _context.Add(categoria);
            _context.SaveChanges();
            return _mapper.Map<ReadCategoriaDto>(categoria);
        }

        public Result AtualizaCategoria(int id, UpdateCategoriaDto updateDto) {
            Categoria categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null) {
                return Result.Fail("Categoria não encontrada");
            }
            _mapper.Map(updateDto, categoria);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCategoria(int id) {
            Categoria categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null) {
                return Result.Fail("Categoria não encontrada");
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
