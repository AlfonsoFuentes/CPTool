using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Commands.Delete
{
    public class DeleteUnitaryBasePrizeCommand : IRequest<DeleteUnitaryBasePrizeCommandResponse>
    {
        public int Id { get; set; }
    }
}
