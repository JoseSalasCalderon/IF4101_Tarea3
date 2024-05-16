using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3.BC.Modelos;

namespace Tarea3.BW.Interfaces.BW
{
    public interface IGestionarListaDeseadosBW
    {
        Task AgregarListaDeseados(ListaDeseados listaDeseados);
        Task<ListaDeseados> buscarListaDeseadosPorID(int id);
        Task<ListaDeseados> buscarListaDeseadosPorProductoID(long idProducto);
        Task EliminarListaDeseados(int id);
        Task ActualizarListaDeseados(ListaDeseados listaDeseados);
        Task AumentarCantidadProductoEnLista(int idListaDeseados);
        Task DisminuirCantidadProductoEnLista(int idListaDeseados);
        Task<decimal> CalcularPrecioTotal();
    }
}
