using MediatR;

namespace webcarsAPI.Aplicacao.Commands;
public class DeletaVeiculoCommand : IRequest<bool>
{
    public Guid VeiculoId { get; set; }

    public DeletaVeiculoCommand(Guid veiculoId)
    {
        VeiculoId = veiculoId;
    }
}
