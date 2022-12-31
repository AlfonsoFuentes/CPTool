using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate
{
    public class MWOTypeCommandResponse : BaseResponse
    {
        public MWOTypeCommandResponse() : base()
        {

        }

        public CommandMWOType? MWOTypeObject { get; set; }
    }
}