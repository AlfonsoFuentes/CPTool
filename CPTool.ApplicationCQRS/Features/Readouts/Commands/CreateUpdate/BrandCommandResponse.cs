using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate
{
    public class ReadoutCommandResponse : BaseResponse
    {
        public ReadoutCommandResponse() : base()
        {

        }

        public CommandReadout? ReadoutObject { get; set; }
    }
}