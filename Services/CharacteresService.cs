using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MundoDisneyChallenge.DAL;
using MundoDisneyChallenge.Models;

namespace MundoDisneyChallenge.Services
{

    public class CharacteresService: IcharacteresService
    {
        public MundoDisneyDbContext _mundoDisneyDbContext;

        public CharacteresService(MundoDisneyDbContext mundoDisneyDbContext)
        {
            _mundoDisneyDbContext = mundoDisneyDbContext;
        }

        public IEnumerable<PersonajeData> getAll()
        {
            IEnumerable<PersonajeData> characteres = _mundoDisneyDbContext.Personajes.Select(x => new PersonajeData { Nombre = x.Nombre, Imagen = x.Imagen }).ToList();

            return characteres;
        }

        public IEnumerable<Personaje> getAllPersonaje()
        {
            IEnumerable<Personaje> characteres = _mundoDisneyDbContext.Personajes;

            return characteres;
        }

        public bool Add(Personaje personaje)
        {
            return (null!=_mundoDisneyDbContext.Personajes.Add(personaje));
        }

        public void Put(int id, Personaje personaje)
        {
           Personaje objPersonaje= _mundoDisneyDbContext.Personajes.Where(x => x.PersonajeID == id).SingleOrDefault();
           objPersonaje = personaje;
            _mundoDisneyDbContext.SaveChanges();
        }


        public void Delete(int id)
        {
            Personaje per = _mundoDisneyDbContext.Personajes.Where(x => x.PersonajeID == id).SingleOrDefault();
            _mundoDisneyDbContext.Personajes.Remove(per);
        }

        public Personaje Detalle(int id)
        {
            return _mundoDisneyDbContext.Personajes.Where(x=>x.PersonajeID==id).SingleOrDefault();

        }

    }
}
