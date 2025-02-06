
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Dominio.Seguranca;
namespace webcarsAPI.Infra.Seguranca.JWT
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly uint _expirationMinutes;
        private readonly string _signinKey;
        public JwtTokenGenerator(string signinKey, uint expirationMinutes)
        {
            _expirationMinutes = expirationMinutes;
            _signinKey = signinKey;
        }

        public string Generate(Usuario usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Sid, usuario.Identificador.ToString()),
                new Claim(ClaimTypes.Role, usuario.Permissao)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signinKey);
            return new SymmetricSecurityKey(key);
        }
       
    }
}