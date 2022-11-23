using System.Text.Json.Serialization;

namespace ChallengeAlura.Models {
    public class Categoria {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Cor { get; set; }
        [JsonIgnore]
        public virtual List<Video> Videos { get; set; }
    }
}
