using AutoMapper;
using ChallengeAlura.Data.Dtos.Videos;
using ChallengeAlura.Models;

namespace ChallengeAlura.Profiles {
    public class VideoProfile : Profile{

        public VideoProfile() {
            CreateMap<CreateVideoDto, Video>();
            CreateMap<Video, ReadVideoDto>();
            CreateMap<UpdateVideoDto, Video>();
        }
    }
}
