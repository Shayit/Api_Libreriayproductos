﻿namespace ORM.DTO.Productos
{
    public class UpdateProductosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Modificado { get; set; }
    }
}
