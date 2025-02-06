using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Responses.Usuario;
using webcarsAPI.Dominio.Repositories.Usuarios;
using webcarsAPI.Dominio.Seguranca;
using webcarsAPI.Exception.ExceptionBase;

namespace webcarsAPI.Aplicacao.UseCase.Usuarios
{
    public class LoginUsuarioUseCase : ILoginUsuarioUseCase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IPasswordIncripty _incripty;
        private readonly ITokenGenerator _tokenGen;
        public LoginUsuarioUseCase(IUsuarioRepository repository, IPasswordIncripty incripty, ITokenGenerator token)
        {
            _repository = repository;
            _incripty = incripty;
            _tokenGen = token;
        }
        public async Task<ResponseUsuarioRegistrado> Execute(RequestLoginUsuario request)
        {
            var user = await _repository.BuscaUsuarioPorEmail(request.Email!);
            if (user == null)
            {
                throw new LoginInvalidException();
            }

            var passwordMatch = _incripty.Verify(request.Senha!, user.Senha!);
            if (passwordMatch == false)
            {
                throw new LoginInvalidException();
            }

            return new ResponseUsuarioRegistrado
            {
                Nome = user.Nome,
                Token = _tokenGen.Generate(user)
            };
        }
    }
}
