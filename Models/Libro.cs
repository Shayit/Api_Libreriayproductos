using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    [Table("libros")]
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Creado {  get; set; }
        public string Modificado { get; set; }
    }
}
