using System.Data;
using FluentValidation;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Exception;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.ValidacoesVeiculo
{
    public class ValidacaoAdicionaVeiculo : AbstractValidator<RequestAdicionaVeiculo>
    {
        public ValidacaoAdicionaVeiculo()
        {
            RuleFor(veiculo => veiculo.Marca).NotEmpty().WithMessage(ResourceErrorMessages.MARCA_VAZIA);
            RuleFor(veiculo => veiculo.Modelo).NotEmpty().WithMessage(ResourceErrorMessages.MODELO_VAZIO);
            RuleFor(veiculo => veiculo.Ano).NotEmpty().WithMessage(ResourceErrorMessages.DATA_INVALIDA);
            RuleFor(veiculo => veiculo.Placa).NotEmpty().WithMessage(ResourceErrorMessages.PLACA_VAZIA);
            RuleFor(veiculo => veiculo.Placa).Length(7).WithMessage(ResourceErrorMessages.PLACA_INVALIDA);
            RuleFor(veiculo => veiculo.Cor).NotEmpty().WithMessage(ResourceErrorMessages.COR_VAZIO);
            RuleFor(veiculo => veiculo.Chassi).NotEmpty().WithMessage(ResourceErrorMessages.CHASSI_VAZIO);
            RuleFor(veiculo => veiculo.Renavam).NotEmpty().WithMessage(ResourceErrorMessages.RENAVAM_VAZIO);
            RuleFor(veiculo => veiculo.Renavam).Length(11).WithMessage(ResourceErrorMessages.RENAVAM_INVALIDO);
        }
    }
}
