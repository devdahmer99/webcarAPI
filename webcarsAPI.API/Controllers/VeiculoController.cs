using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using webcarsAPI.Aplicacao.UseCase.Veiculos.BuscaPorId;
using webcarsAPI.Aplicacao.UseCase.Veiculos.Cadastrar;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAdicionaVeiculo), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraVeiculo([FromServices] IAdicionaVeiculoUseCase useCase, [FromBody] RequestAdicionaVeiculo request)
        {
            var response = await useCase.Execute(request);
            if (response != null)
            {
                return CreatedAtAction(nameof(CadastraVeiculo), response);
            }

            return BadRequest();
        }

        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Upload([FromForm] IFormFile imagem, [FromForm] string userId)
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
    }
}
