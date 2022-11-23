using AutoMapper;
using ChallengeAlura.Data;
using ChallengeAlura.Data.Dtos.Videos;
using ChallengeAlura.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChallengeAlura.Services {
    public class VideoService {

        private VideoDbContext _context;
        private IMapper _mapper;

        public VideoService(VideoDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadVideoDto> BuscaVideo(string? titulo) {
            List<Video> video;
            if (titulo == null) {
                video = _context.Videos.ToList();
            }
            else { 
                video = _context.Videos.Where(video => video.Titulo == titulo).ToList();
            }

            if (video != null) {
                List<ReadVideoDto> readDto = _mapper.Map<List<ReadVideoDto>>(video);
                return readDto;
            }
            return null;
        }

        public ReadVideoDto BuscaVideoPorId(int id) {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video != null) {
                return _mapper.Map<ReadVideoDto>(video);
            }
            return null;
        }

        public ReadVideoDto AdicionaVideo(CreateVideoDto createVideoDto) {
            Video video = _mapper.Map<Video>(createVideoDto);
            _context.Add(video);
            _context.SaveChanges();
            return _mapper.Map<ReadVideoDto>(video);
        }

        public Result AtualizaVideo(int id, UpdateVideoDto updateDto) {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video == null) {
                return Result.Fail("Video não encontrado");
            }
            _mapper.Map(updateDto, video);
            _context.SaveChanges();
            return Result.Ok().WithSuccess("Video Atualizado com sucesso");
        }

        public Result DeletaVideo(int id) {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video == null) {
                return Result.Fail("Video não encontrado");
            }
            _context.Remove(video);
            _context.SaveChanges();
            return Result.Ok().WithSuccess("Video Deletado com sucesso");
        }
    }
}
