using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using webcarsAPI.Aplicacao.Commands;
using webcarsAPI.Comunicacao.Responses.Usuario;
using webcarsAPI.Dominio.Repositories.UnitOfWork;
using webcarsAPI.Dominio.Repositories.Usuarios;
using webcarsAPI.Exception.ExceptionBase;

namespace webcarsAPI.Aplicacao.Handlers.Usuario.CriarUsuario;
public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, ResponseCriaUsuario>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CriarUsuarioCommandHandler(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IUsuarioRepository usuarioRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseCriaUsuario> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var user = new IdentityUser { UserName = request.Nome, Email = request.Email };
        var result = await _userManager.CreateAsync(user, request.Email);

        if(!result.Succeeded)
        {
            var errorMessages = result.Errors.Select(e => e.Description).ToList();
            throw new ErrorOnValidateException(errorMessages);
        }

        if(request.Cargos != null)
        {
            foreach(var cargo in request.Cargos)
            {
                if(!await _roleManager.RoleExistsAsync(cargo))
                {
                    await _roleManager.CreateAsync(new IdentityRole(cargo));
                }
                await _userManager.AddToRoleAsync(user, cargo);
            }
        }

        var usuario = _mapper.Map<Dominio.Entidades.Usuario>(request);
        await _usuarioRepository.AdicionarUsuarioAsync(usuario);
        await _unitOfWork.Commit();

        return new ResponseCriaUsuario
        {
            Nome = usuario.Nome
        };
    }
}
