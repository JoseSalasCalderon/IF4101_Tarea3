using System.Collections.Generic;
using System.Text;
using Tarea3.Api.DTOs;
using Tarea3.BC.Modelos;

namespace Tarea3.Api.Utilitarios
{
    public static class ListaDeseadosDTOMapper
    {
        public static ListaDeseadosDTO ConvertirListaDeseadosADTO(ListaDeseados listaDeseados)
        {
            return new ListaDeseadosDTO()
            {
                idListaDeseado = listaDeseados.idListaDeseado,
                idProducto = listaDeseados.idProducto,
                cantidad = listaDeseados.cantidad
            };
        }

        public static ListaDeseados ConvertirDTOAListaDeseados(ListaDeseadosDTO listaDeseadosDTO)
        {
            return new ListaDeseados()
            {
                idListaDeseado = listaDeseadosDTO.idListaDeseado,
                idProducto = listaDeseadosDTO.idProducto,
                cantidad = listaDeseadosDTO.cantidad
            };
        }

        public static IEnumerable<ListaDeseadosDTO> ConvertirListaDeListaDeseadosADTO(IEnumerable<ListaDeseados> listaDeseados)
        {
            List<ListaDeseadosDTO> listaDeseadosDTO = new List<ListaDeseadosDTO>();

            foreach (var item in listaDeseados)
            {
                listaDeseadosDTO.Add(new ListaDeseadosDTO()
                {
                    idListaDeseado = item.idListaDeseado,
                    idProducto = item.idProducto,
                    cantidad = item.cantidad
                });
            }

            return listaDeseadosDTO;
        }

        public static string ConvertirListaDeListaDeseadosAString(IEnumerable<ListaDeseados> listaDeseados)
        {
            StringBuilder listaDeseadosString = new StringBuilder();

            foreach (var item in listaDeseados)
            {
                listaDeseadosString.AppendLine("ID de la Lista de Deseos: " + item.idListaDeseado);
                listaDeseadosString.AppendLine("ID del Producto: " + item.idProducto);
                listaDeseadosString.AppendLine("Cantidad: " + item.cantidad);
                listaDeseadosString.AppendLine();
            }

            return listaDeseadosString.ToString();
        }
    }
}
