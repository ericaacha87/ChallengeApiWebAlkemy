using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MundoDisneyChallenge.Models
{
    public class Genero
    {
        public int GeneroID { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public ICollection<PeliculaSerie> PeliculaSeries { get; set; }
    }
}
