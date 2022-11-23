using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuarioChallenge.Models;

namespace UsuarioChallenge.Services {
    public class TokenService {

        public Token CreateToken(IdentityUser<int> user, string role) {
            Claim[] direitosUsuario = new Claim[] {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("q3984hf9qhegpojeag093quh4g9hasguj0q93jgqbnur"));
            var credentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
