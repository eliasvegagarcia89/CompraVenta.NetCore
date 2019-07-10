using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using CompraVenta.Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace CompraVenta.Web.Authentication
{
    public class JsonWebToken
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expires_In { get; set; }
        public string Refresh_Token { get; set; }
    }

    public class CompraVentaTokenProvider : ITokenProvider
    {
        private RsaSecurityKey _key;
        private string _algorithm;
        private string _issuer;
        private string _audience;
        public CompraVentaTokenProvider(string issuer, string audience, string keyName)
        {
            // configuración para encriptar el token
            var parameters = new CspParameters { KeyContainerName = keyName };

            var provider = new RSACryptoServiceProvider(2048, parameters);
            _key = new RsaSecurityKey(provider);
            _algorithm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
            _audience = audience;
        }
        public string CreateToken(User user, DateTime expiration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new GenericIdentity(user.Email, "jwt"));
            var token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audience, // clientes JS
                Issuer = _issuer, // Claro, SUNAT, etc...
                SigningCredentials = new SigningCredentials(_key, _algorithm),
                Expires = expiration.ToUniversalTime(), // tiempo de exporación
                Subject = identity // datos que quieren que viajen en el token (encriptados)
            });

            return tokenHandler.WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true
            };
        }
    }
}
