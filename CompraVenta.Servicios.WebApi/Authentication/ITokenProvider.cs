using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraVenta.Dominio.Entidades;
using Microsoft.IdentityModel.Tokens;

namespace CompraVenta.Web.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiration);
        TokenValidationParameters GetValidationParameters();
    }
}
