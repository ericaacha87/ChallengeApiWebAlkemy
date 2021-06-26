using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MundoDisneyChallenge.Models
{
    public class Personaje
    {
        public int PersonajeID { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public float Peso { get; set; }
        public int Edad { get; set; }
        public string Historia { get; set; }
        public virtual ICollection<PeliculaSerie> Peliculas { get; set; }
    }
}
