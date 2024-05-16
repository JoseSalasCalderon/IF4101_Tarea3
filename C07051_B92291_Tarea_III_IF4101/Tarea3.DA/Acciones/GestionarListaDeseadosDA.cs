using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3.BC.Modelos;
using Tarea3.BW.Interfaces.DA;
using Tarea3.DA.Contexto;
using Tarea3.DA.Entidades;

namespace Tarea3.DA.Acciones
{
    public class GestionarListaDeseadosDA : IGestionarListaDeseadosDA
    {
        private readonly Tarea3Context tarea3Context;

        public GestionarListaDeseadosDA(Tarea3Context tarea3Context)
        {
            this.tarea3Context = tarea3Context;
        }
        public async Task AgregarListaDeseados(ListaDeseados listaDeseados)
        {
            var listaDeseadosDA = new ListaDeseadosDA
            {
                idProducto = listaDeseados.idProducto,
                cantidad = listaDeseados.cantidad
            };
            await tarea3Context.listaDeseadosDA.AddAsync(listaDeseadosDA);
            await tarea3Context.SaveChangesAsync();
        }

        public async Task<ListaDeseados> buscarListaDeseadosPorID(int id)
        {
            var listaDeseadosDA = await tarea3Context.listaDeseadosDA.FirstOrDefaultAsync(pr => pr.idListaDeseado == id);
            if (listaDeseadosDA == null)
            {
                return null;
            }
               

             ListaDeseados listaDeseados = new()
            {
                idListaDeseado = listaDeseadosDA.idListaDeseado,
                idProducto = listaDeseadosDA.idProducto,
                cantidad = listaDeseadosDA.cantidad
            };
            return listaDeseados;
        }

        public async Task<ListaDeseados> buscarListaDeseadosPorProductoID(long idProducto)
        {
            var listaDeseadosDA = await tarea3Context.listaDeseadosDA.FirstOrDefaultAsync(ld => ld.idProducto == idProducto);
            if (listaDeseadosDA == null) return null;

            return new ListaDeseados
            {
                idListaDeseado = listaDeseadosDA.idListaDeseado,
                idProducto = listaDeseadosDA.idProducto,
                cantidad = listaDeseadosDA.cantidad
            };
        }

        public async Task EliminarListaDeseados(int id)
        {
            var listaDeseados = await tarea3Context.listaDeseadosDA.FindAsync(id);
            if (listaDeseados != null)
            {
                tarea3Context.listaDeseadosDA.Remove(listaDeseados);
                await tarea3Context.SaveChangesAsync();
            }
        }

        public async Task ActualizarListaDeseados(ListaDeseados listaDeseados)
        {
            var listaDeseadosDA = await tarea3Context.listaDeseadosDA.FindAsync(listaDeseados.idListaDeseado);
            if (listaDeseadosDA != null)
            {
                listaDeseadosDA.idProducto = listaDeseados.idProducto;
                listaDeseadosDA.cantidad = listaDeseados.cantidad;
                await tarea3Context.SaveChangesAsync();
            }
        }

        public async Task<List<ListaDeseados>> ObtenerListaDeseados()
        {
            var listaDeseados = await tarea3Context.listaDeseadosDA
                .Include(ld => ld.ProductoVinculado) 
                .ToListAsync();

            var listaDeseadosConvertida = listaDeseados.Select(ld => new ListaDeseados
            {
                idListaDeseado = ld.idListaDeseado,
                idProducto = ld.idProducto,
                cantidad = ld.cantidad,
                Producto = new Producto
                {
                    idProducto = ld.ProductoVinculado.idProducto,
                    nombre = ld.ProductoVinculado.nombre,
                    precio = ld.ProductoVinculado.precio
                }
            }).ToList();

            return listaDeseadosConvertida;
        }


    }
}
