using webcarsAPI.Dominio.Seguranca.Tokens;

namespace webcarsAPI.API.Token
{
    public class HttpContextTokenValue : ITokenProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HttpContextTokenValue(IHttpContextAccessor contextAcessor)
        {
            _httpContextAccessor = contextAcessor;            
        }

        public string TokenOnRequest()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext!
                                                          .Request
                                                          .Headers
                                                          .Authorization.ToString();

            return authorizationHeader["Bearer ".Length..].Trim();
        }
    }
}
