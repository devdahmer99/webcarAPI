using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using webcarsAPI.Infra.DataAccess;

namespace webcarsAPI.API.Middlewares
{
    public class TokenBlackListMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenBlackListMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token))
            {
                var isBlackList = await dbContext.BlackListTokens.AnyAsync(x => x.Token == token);

                if (isBlackList)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token revogado");
                    return;
                }
            }
            await _next(context);
        }
    }
}
