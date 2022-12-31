using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate
{
    public class PaintingItemCommandResponse : BaseResponse
    {
        public PaintingItemCommandResponse() : base()
        {

        }

        public CommandPaintingItem? PaintingItemObject { get; set; }
    }
}