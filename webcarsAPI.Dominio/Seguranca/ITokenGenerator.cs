using webcarsAPI.Dominio.Entidades;

namespace webcarsAPI.Dominio.Seguranca
{
    public interface ITokenGenerator
    {
        string Generate(Usuario usuario);
    }
}
