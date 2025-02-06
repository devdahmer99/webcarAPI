using System.Globalization;
using webcarsAPI.Dominio.Seguranca;
using BC = BCrypt.Net;

namespace webcarsAPI.Infra.Seguranca.Cripty
{
    internal class Encripty : IPasswordIncripty
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.BCrypt.HashPassword(password);
            return passwordHash;
        }

        public bool Verify(string password, string hash)
        {
            return BC.BCrypt.Verify(password, hash);
        }
    }
}
