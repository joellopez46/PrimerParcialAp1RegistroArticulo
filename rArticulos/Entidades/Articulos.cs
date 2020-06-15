using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroArticulos.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public int Descripcion { get; set; }
        public float Costo { get; set; }
        public float Valor { get; set; }
    }
}
