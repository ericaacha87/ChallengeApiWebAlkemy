using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MundoDisneyChallenge.DAL;
using MundoDisneyChallenge.Models;

namespace MundoDisneyChallenge.Services
{
    public class UsuarioService : IusuarioService
    {

        public MundoDisneyDbContext _mundoDisneyDbContext;

        public UsuarioService(MundoDisneyDbContext mundoDisneyDbContext)
        {
            _mundoDisneyDbContext = mundoDisneyDbContext;
        }


        public void Registrar(Usuario usuario)
        {
            //acceder a DB
            _mundoDisneyDbContext.Usuarios.Add(usuario);
            _mundoDisneyDbContext.SaveChanges();
        }

        public string Autentificar(string email, string contrasenia)
        {
            if (String.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasenia))
            {
                return null;
            }

            Usuario usuario = _mundoDisneyDbContext.Usuarios.SingleOrDefault(x => x.Email == email && x.Contrasenia == contrasenia);
            if (usuario == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("C1CF4B7DC4C4175B6618DE4F55CA4");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, email)

                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }
}
