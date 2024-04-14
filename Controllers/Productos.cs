using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ORM.Context;
using ORM.DTO.Libros;
using ORM.DTO.Productos;
using ORM.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productos : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public Productos(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<Productos>
        [HttpGet]
        public IActionResult Get()
        {
            var productos = _context.Productos.ToList();
            var dto = _mapper.Map<List<ProductosDTO>>(productos);

            return Ok(new { Productos = dto }); //200
        }

        // GET api/<Productos>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productos = _context.Productos.Where(x => x.Id == id).FirstOrDefault();

            if (productos == null)
                return BadRequest("El producto con id indicado no existe."); //400

            var dto = _mapper.Map<ProductosDTO>(productos);
            return Ok(new { Respuesta = productos }); //200
        }

        // POST api/<Productos>
        [HttpPost]
        public IActionResult Post([FromBody] PostProductosDTO dto)
        {
            var entity = _mapper.Map<Producto>(dto);
            _context.Productos.Add(entity);
            _context.SaveChanges();
            return Ok(new { Respuesta = dto, Mensaje = "Registrado con exito" }); //200
        }

        // PUT api/<Productos>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductosDTO dto)
        {
            var productos = _context.Productos.Where(x => x.Id == id).FirstOrDefault();

            if (productos == null)
                return BadRequest("El producto con id indicado no es posible actualizarse."); //400

            var update = _mapper.Map(dto, productos);

            _context.SaveChanges();
            return Ok(new { Respuesta = productos, Mensaje = "Actualizado con exito" }); //200
        }

        // DELETE api/<Productos>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productos = _context.Productos.Where(x => x.Id == id).FirstOrDefault();

            if (productos == null)
                return BadRequest("El producto con id indicado no es posible eliminarlo."); //400

            _context.Productos.Remove(productos);
            _context.SaveChanges();
            return Ok(new { Respuesta = productos, Mensaje = "Eliminado con exito" }); //200
        }
    }
}
