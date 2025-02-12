using Microsoft.AspNetCore.Mvc;
using webcarAPI.Infra.DataAccess;
using webcarsAPI.Infra.DataAccess;

namespace webcarsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpPost("logout")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        ////public async Task<IActionResult> Logout()
        ////{
        ////    var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        ////    if (string.IsNullOrEmpty(token))
        ////    {
        ////        return BadRequest("Token Invalido");
        ////    }

        ////    var blackListToken = new BlackListTokens
        ////    {
        ////        Token = token,
        ////        Expiracao = DateTime.Now.AddHours(1)
        ////    };

        ////    _context.BlackListTokens.Add(blackListToken);
        ////    await _context.SaveChangesAsync();
        ////    return Ok();
        ////}
    }
}
