using AutoMapper;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Repositories.Veiculos;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.Busca;
public class BuscaVeiculosUseCase : IBuscaVeiculosUseCase
{
    private readonly IVeiculosRepository _repository;
    private readonly IMapper _mapper;

    public BuscaVeiculosUseCase(IVeiculosRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseVeiculos> Execute()
    {
        var response = await _repository.BuscarTodosOsVeiculos();

        return new ResponseVeiculos
        {
            Veiculos = _mapper.Map<List<ResponseVeiculo>>(response)
        };
    }
}
