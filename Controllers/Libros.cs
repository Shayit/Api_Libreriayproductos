using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ORM.Context;
using ORM.DTO.Libros;
using ORM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Libros : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public Libros(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<Libros>
        [HttpGet]
        public IActionResult Get()
        {
            var libros = _context.Libros.ToList();
            var dto = _mapper.Map<List<LibroDTO>>(libros);

            return Ok(new {Libros = dto }); //200
        }

        // GET api/<Libros>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var libros = _context.Libros.Where(x => x.Id == id).FirstOrDefault();
  
            if (libros == null)
                return BadRequest("El libro con id indicado no existe."); //400

            var dto = _mapper.Map<LibroDTO>(libros);
            return Ok(new {Respuesta = libros}); //200
        }

        // POST api/<Libros>
        [HttpPost]
        public IActionResult Post([FromBody] PostLibroDTO dto)
        {
            var entity = _mapper.Map<Libro>(dto);
            _context.Libros.Add(entity);
            _context.SaveChanges();
            return Ok(new {Respuesta = dto,Mensaje ="Registrado con exito" }); //200
        }

        // PUT api/<Libros>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateLibroDTO dto)
        {
            var libro = _context.Libros.Where(x=> x.Id == id).FirstOrDefault();

            if(libro == null)
                return BadRequest("El libro con id indicado no es posible actualizarse."); //400

            var update = _mapper.Map(dto, libro);

            _context.SaveChanges();
            return Ok(new { Respuesta = libro, Mensaje = "Actualizado con exito" }); //200
        }

        // DELETE api/<Libros>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var libro = _context.Libros.Where(x => x.Id == id).FirstOrDefault();

            if (libro == null)
                return BadRequest("El libro con id indicado no es posible eliminarlo."); //400

            _context.Libros.Remove(libro);
            _context.SaveChanges();
            return Ok(new { Respuesta = libro, Mensaje = "Eliminado con exito" }); //200
        }
    }
}
