using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_EnmanuelPaulino.Entidades
{
   public class Productos
    {
        [Key]
        public  int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }
    }
    
}
