
using Microsoft.AspNetCore.Mvc;
using webcarsAPI.Aplicacao.UseCase.Usuarios.Criar;
using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Responses.Usuario;

namespace webcarsAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase 
    {       
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCriaUsuario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarUsuario([FromServices] IAdicionarUsuarioUseCase useCase, [FromBody] RequestCriaUsuario request)
        {
            var result = await useCase.Execute(request);
            if(result != null)
            {
                return Created(string.Empty, result);
            }

            return BadRequest();
        }
    }
}