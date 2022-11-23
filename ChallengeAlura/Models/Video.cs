using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace ChallengeAlura.Models {
    public class Video {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }
        public virtual Categoria Categoria { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
