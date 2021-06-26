using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MundoDisneyChallenge.Models;

namespace MundoDisneyChallenge.Services
{
    public interface IusuarioService
    {
        public void Registrar(Usuario usuario);
        public string Autentificar(string email, string contrasenia);

    }



}
