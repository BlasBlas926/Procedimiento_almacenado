using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ProductosMVC.Models
{
    public class Categorias
    {
        [Column("idproducto")]
        public int Id { get; set; }
        [Column("nombre")]
        public string? Nombre { get; set; }
        [Column("precio")]
        public double Precio { get; set; }
        [Column("cantidad")]
        public int Cantidad { get; set; }
        [Column("fecha_registrar")]
        public DateOnly Fecha_Registro { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }
    }
}