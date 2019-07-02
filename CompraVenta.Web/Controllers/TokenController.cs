using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraVenta.UnitOfWork;
using CompraVenta.Web.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompraVenta.Models;

namespace CompraVenta.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unit;

        public TokenController(IUnitOfWork unit, ITokenProvider tokenProvider)
        {
            _unit = unit;
            _tokenProvider = tokenProvider;
        }

        public JsonWebToken Post(User userLogin)
        {
            // obtener el usuario de BD
            var user = _unit.Users.ValidaterUser(userLogin.Email, userLogin.Password);
            if (user == null) throw new UnauthorizedAccessException("Usuario no autorizado");
            // el usuario es válido, entonces generamos el token
            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(userLogin, DateTime.UtcNow.AddHours(8)),
                Expires_In = 8 * 3600
            };
            return token;
        }

    }
}