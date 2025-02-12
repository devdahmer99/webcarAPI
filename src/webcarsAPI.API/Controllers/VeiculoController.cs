using MediatR;
using Microsoft.AspNetCore.Mvc;
using webcarsAPI.Aplicacao.Commands;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("obtemImagem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> obtemImagem()
        {
            var query = new BuscaImagemVeiculoQuery();
            var response = await _mediator.Send(query);
            if(response == null)
            {
                return BadRequest("Não foi possível processar a requisição");
            }

            return Ok(response);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ResponseVeiculo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuscaVeiculos()
        {
            var command = new BuscaTodosVeiculosQuery();
            var response = await _mediator.Send(command);
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(typeof(ResponseAdicionaVeiculo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraVeiculo([FromForm] RequestAdicionaVeiculo request)
        {
            if(request == null)
            {
                return BadRequest("Dados inválidos");
            }

            var command = new CriaVeiculoCommand(request);
            var response = await _mediator.Send(command);

            if(response != null)
            {
                return Created(string.Empty, response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upload([FromForm] IFormFile imagem)
        {
            if (imagem == null)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, imagem.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imagem.CopyToAsync(stream);
            }

            return Ok("Imagem carregada com sucesso.");
        }

        [HttpGet("buscaveiculoporid")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> buscaVeiculoPorId([FromRoute] Guid id)
        {
           var query = new BuscaVeiculoPorIdQuery(id);
           var response = await _mediator.Send(query);
           if(response == null)
            {
                return NotFound("Veiculo não encontrado");
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizaVeiculo([FromRoute] Guid id, [FromBody] RequestAdicionaVeiculo request)
        {
            if (request == null)
            {
                return BadRequest("Dados inválidos");
            }
            var command = new AtualizaVeiculoCommand(id, request);
            var response = await _mediator.Send(command);
            if (response != null)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> deletaVeiculo([FromRoute] Guid id)
        {
            var command = new DeletaVeiculoCommand(id);
            var response = await _mediator.Send(command);
            if(!response)
            {
                return NotFound("Veiculo Não encontrado");
            }
            return NoContent();
        }
    }
}
