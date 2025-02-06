using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CadastraVeiculo([FromServices] IAdicionaVeiculoUseCase useCase,[FromBody] RequestAdicionaVeiculo request)
        {
            var response = await useCase.Execute(request);
            if(response != null)
            {
                return CreatedAtAction(nameof(CadastraVeiculo), response);
            }

            return BadRequest();
        }
    }
}
