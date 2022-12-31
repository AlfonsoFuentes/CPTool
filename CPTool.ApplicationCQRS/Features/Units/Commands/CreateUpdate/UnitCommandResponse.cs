using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate
{
    public class UnitCommandResponse : BaseResponse
    {
        public UnitCommandResponse() : base()
        {

        }

        public CommandUnit? UnitObject { get; set; }
    }
}