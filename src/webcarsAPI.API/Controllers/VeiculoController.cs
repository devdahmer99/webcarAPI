using Microsoft.AspNetCore.Mvc;

namespace webcarsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {


        //[HttpGet("obtemImagem")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> obtemImagem([FromServices] IBuscaVeiculosUseCase useCase)
        //{
        //    var response = await useCase.Execute();

        //    if(response != null)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest();
        //}


        //[HttpGet]
        //[ProducesResponseType(typeof(ResponseVeiculo), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> BuscaVeiculos([FromServices] IBuscaVeiculosUseCase useCase)
        //{
        //    var response = await useCase.Execute();

        //    if(response != null)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest();
        //}


        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //[ProducesResponseType(typeof(ResponseAdicionaVeiculo), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> CadastraVeiculo([FromServices] IAdicionaVeiculoUseCase useCase, [FromForm] RequestAdicionaVeiculo request)
        //{
        //    var response = await useCase.Execute(request);
        //    if (response != null)
        //    {
        //        return CreatedAtAction(nameof(CadastraVeiculo), response);
        //    }

        //    return BadRequest();
        //}

        //[HttpPost("upload")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Upload([FromForm] IFormFile imagem)
        //{
        //    if (imagem == null)
        //    {
        //        return BadRequest("Nenhuma imagem foi enviada.");
        //    }

        //    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        //    if (!Directory.Exists(uploadPath))
        //    {
        //        Directory.CreateDirectory(uploadPath);
        //    }

        //    var filePath = Path.Combine(uploadPath, imagem.FileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await imagem.CopyToAsync(stream);
        //    }

        //    return Ok("Imagem carregada com sucesso.");
        //}

        //[HttpGet("buscaveiculoporid")]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> buscaVeiculoPorId([FromRoute] Guid id, IBuscaVeiculosPorIdUseCase useCase)
        //{
        //    var response = await useCase.Execute(id);
        //    if(response != null)
        //    {
        //        return Ok(response);
        //    }

        //    return BadRequest();
        //}


        //[HttpDelete]
        //[Route("{id}")]
        //[Authorize(Roles = "Admin")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> deletaVeiculo([FromRoute] Guid id, [FromServices] IDeletaVeiculoUseCase useCase)
        //{
        //    var response = await useCase.Execute(id);

        //    if(response)
        //    {
        //        return NoContent();
        //    }

        //    return BadRequest();
        //}

        //[HttpPut]
        //[Route("{id}")]
        //[Authorize(Roles = "Admin")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> atualizaVeiculo([FromRoute] Guid id, [FromServices] IAtualizaVeiculoUseCase useCase, [FromBody] RequestAtualizaVeiculo request)
        //{
        //    try
        //    {
        //        await useCase.Execute(id, request);
        //        return NoContent();
        //    }
        //    catch (webCarsException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
