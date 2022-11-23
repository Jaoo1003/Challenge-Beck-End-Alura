using System.ComponentModel.DataAnnotations;

namespace ChallengeAlura.Data.Dtos.Categorias {
    public class CreateCategoriaDto {
        [Required]
        public string Titulo { get; set; }
        public string Cor { get; set; }
    }
}
