using ChallengeAlura.Models;

namespace ChallengeAlura.Data.Dtos.Categorias {
    public class ReadCategoriaDto {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Cor { get; set; }
        public object Videos { get; set; }
    }
}
