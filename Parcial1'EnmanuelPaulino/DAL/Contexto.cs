using Parcial1_EnmanuelPaulino.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_EnmanuelPaulino.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> productos { get; set; }
        public DbSet<Inventarios> totalInventarios { get; set; }
        public Contexto() : base("ConStr") { }

    }
}
