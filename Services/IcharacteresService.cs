using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MundoDisneyChallenge.Models;

namespace MundoDisneyChallenge.Services
{
    public interface IcharacteresService
    {
        public IEnumerable<PersonajeData> getAll();
        public IEnumerable<Personaje> getAllPersonaje();
        public bool Add(Personaje personaje);
        public void Put(int id, Personaje personaje);
        public void Delete(int id);

        public Personaje Detalle(int id);
    }
}
