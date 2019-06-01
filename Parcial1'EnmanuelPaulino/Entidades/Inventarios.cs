using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_EnmanuelPaulino.Entidades
{
    public class Inventarios
    {
        [Key]
        
        public int InventarioId { get; set; }
        public decimal TotalInventario { get; set; }

        public Inventarios()
        {
            TotalInventario = 0;
            InventarioId = 0;
        }
    }
}
