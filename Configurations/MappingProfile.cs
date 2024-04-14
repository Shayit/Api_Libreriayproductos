using AutoMapper;
using ORM.DTO.Libros;
using ORM.DTO.Productos;
using ORM.Models;

namespace ORM.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Libro, LibroDTO>().ReverseMap();
            CreateMap<Libro, PostLibroDTO>().ReverseMap();
            CreateMap<Libro, UpdateLibroDTO>().ReverseMap();

            CreateMap<Producto, ProductosDTO>().ReverseMap();
            CreateMap<Producto, PostProductosDTO>().ReverseMap();
            CreateMap<Producto, UpdateProductosDTO>().ReverseMap();
        }
    }
}
