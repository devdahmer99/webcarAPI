namespace webcarsAPI.Dominio.Seguranca.Tokens
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
