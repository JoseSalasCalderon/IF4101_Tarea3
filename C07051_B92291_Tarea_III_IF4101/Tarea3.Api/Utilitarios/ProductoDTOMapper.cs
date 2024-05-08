using System.Text;
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

        public static string ConvertirListaDeProductosAString(IEnumerable<Producto> productos)
        {
            StringBuilder productosString = new StringBuilder();

            foreach (Producto producto in productos)
            {
                productosString.AppendLine("ID del Producto " + producto.idProducto);
                productosString.AppendLine(", de nombre " + producto.nombre);
                productosString.AppendLine(", con un precio de " + producto.precio);
                productosString.AppendLine(); // Agregar una línea en blanco entre productos
            }

            return productosString.ToString();
        }

        public static string ConvertiProductoAString(Producto producto)
        {
            StringBuilder productoString = new StringBuilder();
            
            productoString.AppendLine("ID del Producto " + producto.idProducto);
            productoString.AppendLine(", de nombre " + producto.nombre);
            productoString.AppendLine(", con un precio de " + producto.precio);
            

            return productoString.ToString();
        }
    }
}
