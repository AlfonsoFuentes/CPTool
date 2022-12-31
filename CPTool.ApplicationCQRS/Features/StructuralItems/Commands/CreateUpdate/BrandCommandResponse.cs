using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate
{
    public class StructuralItemCommandResponse : BaseResponse
    {
        public StructuralItemCommandResponse() : base()
        {

        }

        public CommandStructuralItem? StructuralItemObject { get; set; }
    }
}