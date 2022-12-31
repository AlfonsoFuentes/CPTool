using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate
{
    public class FoundationItemCommandResponse : BaseResponse
    {
        public FoundationItemCommandResponse() : base()
        {

        }

        public CommandFoundationItem? FoundationItemObject { get; set; }
    }
}