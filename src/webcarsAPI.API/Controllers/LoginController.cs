using Microsoft.AspNetCore.Mvc;

namespace webcarsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //[HttpPost]
        //[ProducesResponseType(typeof(ResponseUsuarioRegistrado), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Login([FromBody] RequestLoginUsuario request)
        //{
        //    var result = await useCase.Execute(request);
        //    if(result != null)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest();
        //}
    }
}
