using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Security
{
    public class TokenManager : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtKey = "FzayqV89UJugzB8n4jacDmgoKut4GQ6p";
            //var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey") ??
            //                                 throw new ArgumentNullException(null, "Key Bilgisi Boş Geldi"));

            var key = Encoding.UTF8.GetBytes(jwtKey) ?? throw new ArgumentNullException(null,"Key Bilgisi Boş Geldi");
            var tokenDescriptor = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(30),
                claims: claims,
                issuer: "http://aasfsdagfsd.com",
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature));

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenDescriptor);
        }
    }
}
