using System.Globalization;

namespace webcarsAPI.Dominio.Seguranca
{
    public interface IPasswordIncripty
    {
        string Encrypt(string senha);
        public bool Verify(string senha, string hash);
    }
}
