using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3.BC.Modelos;
using Tarea3.BW.Interfaces.BW;
using Tarea3.BW.Interfaces.DA;

namespace Tarea3.BW.CU
{
    public class GestionarProductoBW : IGestionarProductoBW
    {
        private readonly IGestionarProductoDA gestionarProductoDA;

        public GestionarProductoBW(IGestionarProductoDA gestionarProductoDA)
        {
            this.gestionarProductoDA = gestionarProductoDA;
        }

        public async Task<IEnumerable<Producto>> listarProductos()
        {
            return await gestionarProductoDA.listarProductos();
        }
    }
}
