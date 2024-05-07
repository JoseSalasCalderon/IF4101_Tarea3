using Alexa.NET.Request;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tarea3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlexaController : ControllerBase
    {
        [HttpPost, Route("/process")]
        public SkillResponse Process(SkillRequest input) {
            
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            output.Response.OutputSpeech = new PlainTextOutputSpeech("Hola, esto funciona");

            return output;
        }
    }
}
