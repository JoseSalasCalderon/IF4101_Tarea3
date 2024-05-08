using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3.BC.Modelos;

namespace Tarea3.BW.Interfaces.DA
{
    public interface IGestionarProductoDA
    {
        Task<IEnumerable<Producto>> listarProductos();

        Task<Producto> buscarProductoPorID(long id);
    }
}
