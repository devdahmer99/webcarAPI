using MediatR;
using webcarsAPI.Aplicacao.Commands;
using webcarsAPI.Comunicacao.Responses.Veiculo;
using webcarsAPI.Dominio.Repositories.Veiculos;

namespace webcarsAPI.Aplicacao.Handlers.Veiculos.BuscaImagens;
public class BuscaImagemVeiculoHandler : IRequestHandler<BuscaImagemVeiculoQuery, IEnumerable<ResponseVeiculoImagem>>
{
    private readonly IVeiculosRepository _veiculosRepository;

    public BuscaImagemVeiculoHandler(IVeiculosRepository veiculosRepository)
    {
        _veiculosRepository = veiculosRepository;
    }

    public async Task<IEnumerable<ResponseVeiculoImagem>> Handle(BuscaImagemVeiculoQuery request, CancellationToken cancellationToken)
    {
        var veiculos = await _veiculosRepository.GetAllVeiculosAsync();

        var imagensResponse = veiculos.Select(v => new ResponseVeiculoImagem
        {
            Imagem = v.Imagem!
        });
        return imagensResponse;
    }
}

