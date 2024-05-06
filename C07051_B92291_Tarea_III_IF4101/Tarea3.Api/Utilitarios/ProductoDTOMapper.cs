using System.Threading;
using Tarea3.Api.DTOs;
using Tarea3.BC.Modelos;

namespace Tarea3.Api.Utilitarios
{
    public static class ProductoDTOMapper
    {
        public static ProductoDTO ConvertirProductoADTO(Producto producto)
        {
            return new ProductoDTO()
            {
                idProducto = producto.idProducto,
                nombre = producto.nombre,
                precio = producto.precio
            };
        }

        public static Producto ConvertirDTOAProducto(ProductoDTO productoDTO)
        {
            return new Producto()
            {
                idProducto = productoDTO.idProducto,
                nombre = productoDTO.nombre,
                precio = productoDTO.precio
            };
        }

        public static IEnumerable<ProductoDTO> ConvertirListaDeProductosADTO(IEnumerable<Producto> productos)
        {

            IEnumerable<ProductoDTO> productosDTO = productos.Select(p => new ProductoDTO()
            {
                idProducto = p.idProducto,
                nombre = p.nombre,
                precio = p.precio
            }
            );
            return productosDTO;
        }
    }
}
