using AutoMapper;
using FluentValidation.Results;
using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Comunicacao.Responses.Usuario;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Dominio.Repositories.UnitOfWork;
using webcarsAPI.Dominio.Repositories.Usuarios;
using webcarsAPI.Dominio.Seguranca;
using webcarsAPI.Exception;
using webcarsAPI.Exception.ExceptionBase;

namespace webcarsAPI.Aplicacao.UseCase.Usuarios.Criar
{
    public class AdicionarUsuarioUseCase : IAdicionarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordIncripty _passwordIncripty;
        private readonly ITokenGenerator _tokenGenerator;
        public AdicionarUsuarioUseCase(IUsuarioRepository usuarioRepository, IUnitOfWork unitOf, IMapper mapper, IPasswordIncripty incripty, ITokenGenerator token)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOf;
            _mapper = mapper;
            _passwordIncripty = incripty;
            _tokenGenerator = token;
        }

        public async Task<ResponseCriaUsuario> Execute(RequestCriaUsuario request)
        {
            await Validate(request);
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Senha = _passwordIncripty.Encrypt(request.Senha!);
            usuario.Identificador = Guid.NewGuid();

            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
            await _unitOfWork.Commit();

            return new ResponseCriaUsuario
            {
                Nome = usuario.Nome,
                Token = _tokenGenerator.Generate(usuario),
            };
        }


        public async Task Validate(RequestCriaUsuario request)
        {
            var result = new ValidacaoCriaUsuario().Validate(request);
            var existeEmail = await _usuarioRepository.VerificaExistenciaUsuarioPorEmail(request.Email!);
            if (existeEmail)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_EXISTE));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();

                throw new ErrorOnValidateException(errorMessages);
            }
        }
    }
}