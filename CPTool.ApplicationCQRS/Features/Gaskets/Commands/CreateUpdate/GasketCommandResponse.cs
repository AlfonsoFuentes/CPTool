using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate
{
    public class GasketCommandResponse : BaseResponse
    {
        public GasketCommandResponse() : base()
        {

        }

        public CommandGasket? GasketObject { get; set; }
    }
}