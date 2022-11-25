using AutoMapper;
using ChallengeAlura.Data.Dtos.Videos;
using ChallengeAlura.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ChallengeAlura.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase{

        private VideoService _videoService;
        private IMapper _mapper;

        public VideoController(VideoService videoService, IMapper mapper) {
            _videoService = videoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "authorizeduser")]
        public IActionResult BuscaVideo([FromQuery] string? titulo) {
            List<ReadVideoDto> readDto = _videoService.BuscaVideo(titulo);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}/videos")]
        [Authorize(Roles = "authorizeduser")]
        public IActionResult BuscaVideoPorId(int id) {
            ReadVideoDto readDto = _videoService.BuscaVideoPorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "authorizeduser")]
        public IActionResult AdicionaVideo(CreateVideoDto createVideoDto) {
            ReadVideoDto readDto = _videoService.AdicionaVideo(createVideoDto);
            return CreatedAtAction(nameof(BuscaVideoPorId), new {Id = readDto.Id}, readDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "authorizeduser")]
        public IActionResult AtualizaVideo(int id, [FromBody]UpdateVideoDto updateDto) {
            Result resultado = _videoService.AtualizaVideo(id, updateDto);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "authorizeduser")]
        public IActionResult DeletaVideo(int id) {
            Result resultado = _videoService.DeletaVideo(id);
            if (resultado.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}
