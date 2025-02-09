using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using webcarsAPI.Comunicacao.Responses.Veiculo;

namespace webcarsAPI.Aplicacao.UseCase.Veiculos.BuscaPorId
{
    public interface IBuscaVeiculosPorIdUseCase
    {
        Task<ResponseVeiculo> Execute(int veiculoId);
    }
}
