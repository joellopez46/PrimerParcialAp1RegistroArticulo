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
            public string Descripcion { get; set; }
            public decimal Existencia { get; set; }
            public decimal Costo { get; set; }
            public decimal Valorinventario { get; set; }
   
        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            Valorinventario = 0;
        }
    }
}
