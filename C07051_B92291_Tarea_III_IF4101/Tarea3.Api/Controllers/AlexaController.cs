using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea3.Api.Utilitarios;
using Tarea3.BC.Modelos;
using Tarea3.BW.CU;
using Tarea3.BW.Interfaces.BW;

namespace Tarea3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : ControllerBase
    {
        private readonly IGestionarProductoBW gestionarProductoBW;
        private readonly IGestionarListaDeseadosBW gestionarListaDeseadosBW;

        public AlexaController(IGestionarProductoBW gestionarProductoBW)
        {
            this.gestionarProductoBW = gestionarProductoBW;
        }

        [HttpPost, Route("/process")]
        public async Task<SkillResponse> Process(SkillRequest input) {
            
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            switch (input.Request.Type)
            {
                //Se valida el caso inicial
                case "LaunchRequest":
                    output.Response.OutputSpeech = new PlainTextOutputSpeech("Hola, bienvenido al ejemplo de manejador de productos para la tarea tres!!");
                    break;
                case "IntentRequest":
                    IntentRequest intentRequest = (IntentRequest)input.Request;
                    switch (intentRequest.Intent.Name) 
                    {
                        case "listar_productos_intent":
                            IEnumerable<Producto> productos = await gestionarProductoBW.listarProductos();
                            string productosString = ProductoDTOMapper.ConvertirListaDeProductosAString(productos);
                            output.Response.OutputSpeech = 
                                new PlainTextOutputSpeech("La lista de productos es la siguiente: "+productosString);
                            output.Response.ShouldEndSession = false;
                            break;
                        case "buscar_producto_intent":
                            long idProducto = Convert.ToInt64(intentRequest.Intent.Slots["idProducto"].SlotValue.Value);
                            Producto producto = await gestionarProductoBW.buscarProductoPorID(idProducto);
                            if (producto == null) 
                            {
                                output.Response.OutputSpeech =
                                    new PlainTextOutputSpeech("Lo siento, pero el producto con el id " + idProducto + " no está registrado.");
                                break;
                            }
                            string productoString = ProductoDTOMapper.ConvertiProductoAString(producto);
                            output.Response.OutputSpeech =
                                new PlainTextOutputSpeech("Correcto, el producto solicitado es el siguiente: " + productoString);
                            break;
                        case "eliminar_lista_deseados_intent":
                            int idListaDeseados = Convert.ToInt32(intentRequest.Intent.Slots["idListaDeseados"].SlotValue.Value);
                            var listaDeseados = await gestionarListaDeseadosBW.buscarListaDeseadosPorID(idListaDeseados);
                            if (listaDeseados == null)
                            {
                                output.Response.OutputSpeech = new PlainTextOutputSpeech("Lo siento, pero la lista de deseos con el id " + idListaDeseados + " no está registrada.");
                            }
                            else
                            {
                                await gestionarListaDeseadosBW.EliminarListaDeseados(idListaDeseados);
                                output.Response.OutputSpeech = new PlainTextOutputSpeech("La lista de deseos con el id " + idListaDeseados + " ha sido eliminada correctamente.");
                            }
                            break;
                        case "aumentar_cantidad_producto_intent":
                            int idListaDeseadosAumento = Convert.ToInt32(intentRequest.Intent.Slots["idListaDeseados"].SlotValue.Value);
                            await gestionarListaDeseadosBW.AumentarCantidadProductoEnLista(idListaDeseadosAumento);
                            output.Response.OutputSpeech = new PlainTextOutputSpeech("La cantidad del producto en la lista de deseos ha sido aumentada correctamente.");
                            break;

                        case "disminuir_cantidad_producto_intent":
                            int idListaDeseadosDisminucion = Convert.ToInt32(intentRequest.Intent.Slots["idListaDeseados"].SlotValue.Value);
                            await gestionarListaDeseadosBW.DisminuirCantidadProductoEnLista(idListaDeseadosDisminucion);
                            output.Response.OutputSpeech = new PlainTextOutputSpeech("La cantidad del producto en la lista de deseos ha sido disminuida correctamente.");
                            break;

                        case "calcular_precio_total_intent":
                            decimal precioTotal = await gestionarListaDeseadosBW.CalcularPrecioTotal();
                            output.Response.OutputSpeech = new PlainTextOutputSpeech("El precio total de los productos en la lista de deseos es " + precioTotal.ToString("C"));
                        break;
                    }
                break;

            }
            return output;
        }
    }
}
