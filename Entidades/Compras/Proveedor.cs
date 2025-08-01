﻿using System.ComponentModel.DataAnnotations;

namespace Entidades.Compras
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Cuit { get; set; }
        public bool Activo { get; set; } = true;
    }
}
