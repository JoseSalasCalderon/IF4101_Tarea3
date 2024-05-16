using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3.BC.Modelos
{
    public class ListaDeseados
    {
        public int idListaDeseado { get; set; }
        public long idProducto { get; set; }
        public int cantidad { get; set; }
        public Producto Producto { get; set; }
    }
}
