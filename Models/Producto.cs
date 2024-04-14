using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    [Table("Productos")]
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public string Creado { get; set; }
        public string Modificado { get; set; }
    }
}
