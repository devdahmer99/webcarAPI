using MediatR;
using Microsoft.AspNetCore.Mvc;
using webcarsAPI.Aplicacao.Commands;
using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Responses.Usuario;

namespace webcarsAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase 
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCriaUsuario), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegistrarUsuario([FromBody] RequestCriaUsuario request)
        {
            var command = new CriarUsuarioCommand
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
                Cargos = request.Cargos
            };

            var result = await _mediator.Send(command);
            if(result != null)
            {
                return Created(string.Empty, result);
            }

            return BadRequest();
        }
    }
}