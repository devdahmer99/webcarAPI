using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Repositories.Veiculos;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.BuscaPorId
{
    internal class BuscaVeiculosPorIdUseCase : IBuscaVeiculosPorIdUseCase
    {
        private readonly IVeiculosRepository _repository;
        private readonly IMapper _mapper;
        public BuscaVeiculosPorIdUseCase(IVeiculosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseVeiculo> Execute(int veiculoId)
        {
            var veiculo = await _repository.BuscaVeiculoPorId(veiculoId);
            if(veiculo == null)
            {
                throw new ArgumentException("Veiculo não encontrado!");
            }

            return _mapper.Map<ResponseVeiculo>(veiculo);
        }
    }
}
