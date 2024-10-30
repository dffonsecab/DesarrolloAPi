using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebPersonal.Shared.v1;

namespace WebPersonal.Controllers
{

    
    [Route("api/v{version:int}/[Controller]")]
    [ApiController]
    [ApiVersion("1")]

    public class PerfilPersonalController : ControllerBase {


        /* ------ Leeer------- */

        [HttpGet("LeerPerfil/{id}")]
        public string Get(int id)
        {
            return id switch
            {

                1 => "Diego",
                2 => "Ing Sistemas",
                _ => throw new NotSupportedException("El id no es valido")


            };

        }


        /* ----- Guardar ----- */

        [HttpPost("Guardar")]
        public IActionResult Post(PerfilDto perfil)
        {
            PerfilDto _perfilDTO = new PerfilDto
            {
                Nombre = perfil.Nombre,
                Direccion = perfil.Direccion,
                Telefono = perfil.Telefono,

            };
          
            return StatusCode(StatusCodes.Status200OK,  _perfilDTO );

        }



    }



}


