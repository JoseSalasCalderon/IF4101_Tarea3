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
    public class GestionarListaDeseadosBW : IGestionarListaDeseadosBW
    {
        private readonly IGestionarListaDeseadosDA gestionarListaDeseadosDA;

        public GestionarListaDeseadosBW(IGestionarListaDeseadosDA gestionarListaDeseadosDA)
        {
            this.gestionarListaDeseadosDA = gestionarListaDeseadosDA;
        }

        public async Task AgregarListaDeseados(ListaDeseados listaDeseados)
        {
            await gestionarListaDeseadosDA.AgregarListaDeseados(listaDeseados);
        }

        public async Task<ListaDeseados> buscarListaDeseadosPorID(int id)
        {
            return await gestionarListaDeseadosDA.buscarListaDeseadosPorID(id);
        }

        public async Task<ListaDeseados> buscarListaDeseadosPorProductoID(long idProducto)
        {
            return await gestionarListaDeseadosDA.buscarListaDeseadosPorProductoID(idProducto);
        }

        public async Task EliminarListaDeseados(int id)
        {
            await gestionarListaDeseadosDA.EliminarListaDeseados(id);
        }

        public async Task ActualizarListaDeseados(ListaDeseados listaDeseados)
        {
            await gestionarListaDeseadosDA.ActualizarListaDeseados(listaDeseados);
        }

        public async Task AumentarCantidadProductoEnLista(int idListaDeseados)
        {
            var listaDeseados = await gestionarListaDeseadosDA.buscarListaDeseadosPorID(idListaDeseados);
            if (listaDeseados != null)
            {
                listaDeseados.cantidad++;
                await gestionarListaDeseadosDA.ActualizarListaDeseados(listaDeseados);
            }
        }

        public async Task DisminuirCantidadProductoEnLista(int idListaDeseados)
        {
            var listaDeseados = await gestionarListaDeseadosDA.buscarListaDeseadosPorID(idListaDeseados);
            if (listaDeseados != null && listaDeseados.cantidad > 0)
            {
                listaDeseados.cantidad--;
                if (listaDeseados.cantidad == 0)
                {
                    await EliminarListaDeseados(idListaDeseados);
                }
                else
                {
                    await gestionarListaDeseadosDA.ActualizarListaDeseados(listaDeseados);
                }
            }
        }


        public async Task<decimal> CalcularPrecioTotal()
        {
            var listaDeseados = await gestionarListaDeseadosDA.ObtenerListaDeseados();
            if (listaDeseados == null || !listaDeseados.Any())
            {
                return 0;
            }

            decimal precioTotal = 0;
            foreach (var item in listaDeseados)
            {
                precioTotal += item.Producto.precio * item.cantidad;
            }

            decimal impuesto = precioTotal * 0.13m;
            decimal precioTotalConIva = precioTotal + impuesto;

            return precioTotalConIva;
        }
    }
}
