using AutoMapper;
using FluentValidation.Results;
using webcarsAPI.Aplicacao.UseCase.Veiculos.Cadastrar;
using webcarsAPI.Aplicacao.UseCase.Veiculos.ValidacoesVeiculo;
using webcarsAPI.Comunicacao.Requests.Veiculos;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Dominio.Repositories.UnitOfWork;
using webcarsAPI.Dominio.Repositories.Veiculos;
using webcarsAPI.Exception;
using webcarsAPI.Exception.ExceptionBase;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.Cadastrar
{
    public class AdicionaVeiculoUseCase : IAdicionaVeiculoUseCase
    {
        private readonly IVeiculosRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AdicionaVeiculoUseCase(IVeiculosRepository repository, IMapper mapper, IUnitOfWork unitOf)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOf;
        }
        public async Task<ResponseAdicionaVeiculo> Execute(RequestAdicionaVeiculo request)
        {
            await Validate(request);

            string? imagemData = null;

            if (!string.IsNullOrEmpty(request.Imagem))
            {
                imagemData = request.Imagem;
            }

            var veiculo = _mapper.Map<Veiculo>(request);
            await _repository.AdicionarVeiculo(veiculo);
            await _unitOfWork.Commit();

            return new ResponseAdicionaVeiculo
            {
                UsuarioId  = veiculo.UsuarioId,
                Descricao = veiculo.Descricao,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Placa = veiculo.Placa,
                Cor = veiculo.Cor,
                Chassi = veiculo.Chassi,
                Renavam = veiculo.Renavam,
                Quilometragem = veiculo.Quilometragem,
                Combustivel = veiculo.Combustivel,
                Cidade = veiculo.Cidade,
                Telefone = veiculo.Telefone,
                Valor = veiculo.Valor,
                Imagem = imagemData
            };
        }

        public async Task Validate(RequestAdicionaVeiculo request)
        {
            var result = new ValidacaoAdicionaVeiculo().Validate(request);

            var placaJaCadastrada = await _repository.ExistePlacaCadastrada(request.Placa!);
            var renavamJaCadastrado = await _repository.ExisteRenavam(request.Renavam!);
            var chassiCadastrado = await _repository.ExisteChassi(request.Chassi!);

            if(placaJaCadastrada || renavamJaCadastrado || chassiCadastrado)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PLACA_JA_EXISTE));
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.RENAVAM_EXISTE));
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.CHASSI_JA_CADASTRADO));
            }

            if(result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(err => err.ErrorMessage).ToList();
                throw new ErrorOnValidateException(errorMessages);
            }
        }
    }
}
