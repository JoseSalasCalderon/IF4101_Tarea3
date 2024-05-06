using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tarea3.BC.Modelos;
using Tarea3.BW.Interfaces.DA;
using Tarea3.DA.Contexto;

namespace Tarea3.DA.Acciones
{
    public class GestionarProductoDA : IGestionarProductoDA
    {
        private readonly Tarea3Context tarea3Context;

        public GestionarProductoDA(Tarea3Context tarea3Context)
        {
            this.tarea3Context = tarea3Context;
        }

        public async Task<IEnumerable<Producto>> listarProductos()
        {
            return await tarea3Context.productoDA.
                Select(productoDA => new Producto
                {
                    idProducto = productoDA.idProducto,
                    nombre = productoDA.nombre,
                    precio = productoDA.precio

                }).ToListAsync();
        }
    }
}
