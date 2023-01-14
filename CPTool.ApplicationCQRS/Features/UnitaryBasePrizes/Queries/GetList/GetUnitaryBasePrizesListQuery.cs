using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetList
{
    public class GetUnitaryBasePrizesListQuery : IRequest<List<CommandUnitaryBasePrize>>
    {

    }
}
