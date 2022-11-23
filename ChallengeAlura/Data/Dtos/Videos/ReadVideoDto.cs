using ChallengeAlura.Models;

namespace ChallengeAlura.Data.Dtos.Videos {
    public class ReadVideoDto {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public Categoria Categoria { get; set; }
    }
}
