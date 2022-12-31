using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate
{
    public class UnitaryBasePrizeCommandResponse : BaseResponse
    {
        public UnitaryBasePrizeCommandResponse() : base()
        {

        }

        public CommandUnitaryBasePrize? UnitaryBasePrizeObject { get; set; }
    }
}