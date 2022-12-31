using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate
{
    public class MWOItemCommandResponse : BaseResponse
    {
        public MWOItemCommandResponse() : base()
        {

        }

        public CommandMWOItem? MWOItemObject { get; set; }
    }
}