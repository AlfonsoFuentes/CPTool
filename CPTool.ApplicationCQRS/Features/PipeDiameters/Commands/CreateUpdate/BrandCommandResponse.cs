using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate
{
    public class PipeDiameterCommandResponse : BaseResponse
    {
        public PipeDiameterCommandResponse() : base()
        {

        }

        public CommandPipeDiameter? PipeDiameterObject { get; set; }
    }
}