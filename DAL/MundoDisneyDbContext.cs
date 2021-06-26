using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MundoDisneyChallenge.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MundoDisneyChallenge.DAL
{
    public class MundoDisneyDbContext: DbContext
    {
        public MundoDisneyDbContext(DbContextOptions<MundoDisneyDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseSqlServer(@"Server=xxxxx; Database=MundoDisneyChallenge; Trusted_Connection=True",
            options => options.EnableRetryOnFailure());
           
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<PeliculaSerie> PeliculaSeries { get; set; }
        public DbSet<Personaje> Personajes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
       
    }
}
