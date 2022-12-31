using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate
{
    public class PipingItemCommandResponse : BaseResponse
    {
        public PipingItemCommandResponse() : base()
        {

        }

        public CommandPipingItem? PipingItemObject { get; set; }
    }
}