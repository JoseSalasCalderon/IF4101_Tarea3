using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3.DA.Entidades;

namespace Tarea3.DA.Contexto
{
    public class Tarea3Context : DbContext
    {
        public Tarea3Context(DbContextOptions options) 
            : base(options) 
        { 
        }

        public DbSet<ProductoDA> productoDA { get; set; }

        public DbSet<ListaDeseadosDA> listaDeseadosDA { get; set; }


    }
}
