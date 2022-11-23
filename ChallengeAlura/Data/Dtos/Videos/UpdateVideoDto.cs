using System.ComponentModel.DataAnnotations;

namespace ChallengeAlura.Data.Dtos.Videos {
    public class UpdateVideoDto {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
