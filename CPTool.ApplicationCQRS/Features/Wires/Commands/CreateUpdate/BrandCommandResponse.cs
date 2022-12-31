using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate
{
    public class WireCommandResponse : BaseResponse
    {
        public WireCommandResponse() : base()
        {

        }

        public CommandWire? WireObject { get; set; }
    }
}