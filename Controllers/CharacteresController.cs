using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MundoDisneyChallenge.Services;
using Microsoft.AspNetCore.Authorization;
using MundoDisneyChallenge.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MundoDisneyChallenge.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CharacteresController : ControllerBase
    {
        private IcharacteresService _characteresService;



        public CharacteresController(IcharacteresService characteresService)
        {
            _characteresService = characteresService;
        }


        // GET: api/<CharacteresController>
        [AllowAnonymous]
        [Route("characteres")]
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_characteresService.getAll());

        }

        // GET api/<CharacteresController>/5
        

        // POST api/<CharacteresController>
        [Route("Agregar")]
        [HttpPost]
        public void Post(Personaje personaje)
        {
            _characteresService.Add(personaje);
        }

        // PUT api/<CharacteresController>/5
        [Route("actualizar")]
        [HttpPut]
        public void Put(int id, Personaje personaje)
        {
            _characteresService.Put(id, personaje);
        }

        // DELETE api/<CharacteresController>/5
        [Route("borrar")]
        [HttpDelete]

        public void Delete(int id)
        {
            _characteresService.Delete(id);
        }
     
        [Route("Detalle/{id}")]
        [HttpGet]
        public IActionResult Detalle(int id)
        {
           return Ok(_characteresService.Detalle(id));
        }
     
        [AllowAnonymous]
        [Route("characteres/{searcher}")]
        [HttpGet]
        public IActionResult GetAllPersonaje(string searcher)
        {

            return Ok(_characteresService.getAllPersonaje().ToList().Where(x=>x.Nombre.Contains(searcher) || x.Edad.CompareTo(Int64.Parse(searcher))>0  )            
                );

        }
    }
}
