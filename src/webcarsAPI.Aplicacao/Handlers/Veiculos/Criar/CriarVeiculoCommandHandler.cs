using AutoMapper;
using MediatR;
using webcarAPI.Infra.DataAccess;
using webcarsAPI.Aplicacao.Commands;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Entidades;
using webcarsAPI.Dominio.Repositories.Veiculos;

namespace webcarsAPI.Aplicacao.Handlers.Veiculos.Criar;
public class CriarVeiculoCommandHandler : IRequestHandler<CriaVeiculoCommand, ResponseAdicionaVeiculo>
{
    private readonly IVeiculosRepository _repository;
    private readonly IMapper _mapper;

    public CriarVeiculoCommandHandler(IVeiculosRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseAdicionaVeiculo> Handle(CriaVeiculoCommand request, CancellationToken cancellationToken)
    {
        var veiculoEntidade = _mapper.Map<Veiculo>(request);

        veiculoEntidade = await _repository.AddVeiculoAsync(veiculoEntidade);

        var response = _mapper.Map<ResponseAdicionaVeiculo>(veiculoEntidade);
        return response;
    }
}