using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_EnmanuelPaulino.Entidades
{
    public class TotalInventarios
    {
        [Key]
        public decimal TotalInventario { get; set; }
        public int InventarioId { get; set; }
        public int ProductoId { get; set; }


        public TotalInventarios()
        {
            TotalInventario = 0;
            InventarioId = 0;
            ProductoId = 0;
        }
    }
}
