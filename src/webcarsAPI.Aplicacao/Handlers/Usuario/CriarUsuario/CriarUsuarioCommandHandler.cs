using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using webcarsAPI.Aplicacao.Commands;
using webcarsAPI.Comunicacao.Responses.Usuario;
using webcarsAPI.Exception.ExceptionBase;
using webcarsAPI.Infra.Services;

namespace webcarsAPI.Aplicacao.Handlers.Usuario.CriarUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, ResponseCriaUsuario>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public CriarUsuarioCommandHandler(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IRoleService roleService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _roleService = roleService;
        }

        public async Task<ResponseCriaUsuario> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Process the username to remove spaces and special characters
            string processedUserName = Regex.Replace(request.Nome, @"[^a-zA-Z0-9]", "");

            // Create the user directly in AspNetUsers using IdentityUser
            var user = new IdentityUser { UserName = processedUserName, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Senha);

            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description).ToList();
                throw new ErrorOnValidateException(errorMessages);
            }

            // Optionally add a login for the user in AspNetUserLogins
            var loginInfo = new UserLoginInfo("DefaultProvider", processedUserName, "DefaultProviderDisplayName");
            var loginResult = await _userManager.AddLoginAsync(user, loginInfo);

            if (!loginResult.Succeeded)
            {
                var errorMessages = loginResult.Errors.Select(e => e.Description).ToList();
                throw new ErrorOnValidateException(errorMessages);
            }

            if (request.Cargos != null)
            {
                foreach (var cargo in request.Cargos)
                {
                    await _roleService.EnsureRoleAsync(cargo);
                    await _userManager.AddToRoleAsync(user, cargo);
                }
            }

            return new ResponseCriaUsuario
            {
                Nome = processedUserName,
                Email = user.Email,
                Id = user.Id
            };
        }
    }
}