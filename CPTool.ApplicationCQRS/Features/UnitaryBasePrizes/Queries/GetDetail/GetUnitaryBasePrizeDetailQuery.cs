using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetDetail
{
    public class GetUnitaryBasePrizeDetailQuery : IRequest<CommandUnitaryBasePrize>
    {
        public int Id { get; set; }
    }
}
