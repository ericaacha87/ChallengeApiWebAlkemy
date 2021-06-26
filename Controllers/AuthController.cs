using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MundoDisneyChallenge.Models;
using MundoDisneyChallenge.Services;
using MundoDisneyChallenge.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MundoDisneyChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IusuarioService _usuarioService;
       
        private string _key;

        // GET: api/<UsuarioController>

        public AuthController(IusuarioService usuarioService) {
            _usuarioService = usuarioService;
        }


        

        [Route("register")]
        [HttpPost]
        public IActionResult Registrar(Usuario usuario)
        {
            _usuarioService.Registrar(usuario);
            return CreatedAtAction(nameof(Registrar), new { id = usuario.UsuarioID }, usuario);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Autentificar(LoginUsuario autentificacionUsuario)
        {
            
            var responseJwt = _usuarioService.Autentificar(autentificacionUsuario.Email, autentificacionUsuario.Contrasenia);

            return Ok(responseJwt);

           
         //   return CreatedAtAction(nameof(LoginUsuario), new { id = autentificacionUsuario.Contrasenia }, autentificacionUsuario);
        }
        // GET api/<UsuarioController>/5

        // PUT api/<UsuarioController>/5
       
        // DELETE api/<UsuarioController>/5
       
    }
}
