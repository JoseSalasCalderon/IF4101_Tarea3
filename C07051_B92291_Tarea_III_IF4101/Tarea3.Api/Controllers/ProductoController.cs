using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Tarea3.Api.DTOs;
using Tarea3.Api.Utilitarios;
using Tarea3.BC.Modelos;
using Tarea3.BW.Interfaces.BW;

namespace Tarea3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGestionarProductoBW gestionarProductoBW;

        public ProductoController(IGestionarProductoBW gestionarProductoBW)
        {
            this.gestionarProductoBW = gestionarProductoBW;
        }

        [HttpGet("ObtenerTodasLosProductos")]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> obtenerTodasLosProductos()
        {
            //Es necesario decirle a las tareas que terminen primero para manipularlas
            IEnumerable<Producto> productos = await gestionarProductoBW.listarProductos();

            return Ok(ProductoDTOMapper.ConvertirListaDeProductosADTO(productos));
        }

        [HttpGet("buscarProductoPorID/{id}")]
        public async Task<ActionResult<ProductoDTO>> buscarProductoPorID(long id)
        {
            Producto producto = await gestionarProductoBW.buscarProductoPorID(id);

            if (producto == null)
            {
                return NotFound(); // Producto no encontrado
            }

            return Ok(ProductoDTOMapper.ConvertirProductoADTO(producto));
        }
    }
}
