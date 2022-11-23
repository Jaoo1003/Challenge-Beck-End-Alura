using System.ComponentModel.DataAnnotations;

namespace UsuarioChallenge.Data.Request {
    public class LoginRequest {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}