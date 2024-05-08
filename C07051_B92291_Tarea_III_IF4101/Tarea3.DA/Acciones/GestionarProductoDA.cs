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

        public async Task<Producto> buscarProductoPorID(long id)
        {
            var productoDA = await tarea3Context.productoDA.FirstOrDefaultAsync(pr => pr.idProducto == id);

            if (productoDA == null)
            {
                return null;
            }

            Producto producto = new()
            {
                idProducto = productoDA.idProducto,
                nombre = productoDA.nombre,
                precio = productoDA.precio
            };

            return producto;
        }
    }
}
