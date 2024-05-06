using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3.DA.Contexto
{
    public class Tarea3Context : DbContext
    {
        public Tarea3Context(DbContextOptions options) 
            : base(options) 
        { 
        }


    }
}
