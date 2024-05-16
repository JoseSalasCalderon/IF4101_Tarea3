using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea3.Api.DTOs;
using Tarea3.BC.Modelos;
using Tarea3.BW.Interfaces.BW;

namespace Tarea3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeseadosController : ControllerBase
    {
        private readonly IGestionarListaDeseadosBW gestionarListaDeseadosBW;
        private readonly IGestionarProductoBW gestionarProductoBW;

        public ListaDeseadosController(IGestionarListaDeseadosBW gestionarListaDeseadosBW, IGestionarProductoBW gestionarProductoBW)
        {
            this.gestionarListaDeseadosBW = gestionarListaDeseadosBW;
            this.gestionarProductoBW = gestionarProductoBW;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarListaDeseados(int id)
        {
            await gestionarListaDeseadosBW.EliminarListaDeseados(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarListaDeseados([FromBody] ListaDeseadosDTO listaDeseadosDTO)
        {
            var producto = await gestionarProductoBW.buscarProductoPorID(listaDeseadosDTO.idProducto);
            if (producto == null)
            {
                return BadRequest("El producto no existe.");
            }

            var listaDeseadosExistente = await gestionarListaDeseadosBW.buscarListaDeseadosPorProductoID(listaDeseadosDTO.idProducto);
            if (listaDeseadosExistente != null)
            {
                return Conflict("El producto ya está en la lista de deseos.");
            }

            var listaDeseados = new ListaDeseados
            {
                idProducto = listaDeseadosDTO.idProducto,
                cantidad = listaDeseadosDTO.cantidad
            };

            await gestionarListaDeseadosBW.AgregarListaDeseados(listaDeseados);

            return CreatedAtAction(nameof(AgregarListaDeseados), new { id = listaDeseados.idListaDeseado }, listaDeseadosDTO);
        }

        [HttpPost("{id}/AumentarCantidad")]
        public async Task<IActionResult> AumentarCantidadProductoEnLista(int id)
        {
            await gestionarListaDeseadosBW.AumentarCantidadProductoEnLista(id);
            return Ok();
        }

        [HttpPost("{id}/DisminuirCantidad")]
        public async Task<IActionResult> DisminuirCantidadProductoEnLista(int id)
        {
            await gestionarListaDeseadosBW.DisminuirCantidadProductoEnLista(id);
            return Ok();
        }

        [HttpGet("CalcularPrecioTotal")]
        public async Task<IActionResult> CalcularPrecioTotal()
        {
            try
            {
                var precioTotal = await gestionarListaDeseadosBW.CalcularPrecioTotal();

                return Ok(new { PrecioTotal = precioTotal });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al calcular el precio total: " + ex.Message);
            }
        }

    }
}
