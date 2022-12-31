using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate
{
    public class TaksCommandResponse : BaseResponse
    {
        public TaksCommandResponse() : base()
        {

        }

        public CommandTaks? TaksObject { get; set; }
    }
}