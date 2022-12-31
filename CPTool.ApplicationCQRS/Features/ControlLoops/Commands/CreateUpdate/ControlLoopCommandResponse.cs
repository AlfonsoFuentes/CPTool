using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate
{
    public class ControlLoopCommandResponse : BaseResponse
    {
        public ControlLoopCommandResponse() : base()
        {

        }

        public CommandControlLoop? ControlLoopObject { get; set; }
    }
}