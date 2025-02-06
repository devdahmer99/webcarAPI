using FluentValidation;
using webcarsAPI.Comunicacao.Requests.Usuarios;
using webcarsAPI.Exception;

namespace webcarsAPI.Aplicacao.UseCase.Usuarios.ValicaoesUsuario
{
    public class ValidacaoCriaUsuario : AbstractValidator<RequestCriaUsuario>
    {
        public ValidacaoCriaUsuario()
        {
            RuleFor(user => user.Nome).NotEmpty().WithMessage(ResourceErrorMessages.NOME_VAZIO);
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.EMAIL_VAZIO)
                .EmailAddress()
                .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage(ResourceErrorMessages.EMAIL_INVALIDO);
            RuleFor(user => user.Senha).SetValidator(new ValidacaoSenha<RequestCriaUsuario>());
        }
    }
}
