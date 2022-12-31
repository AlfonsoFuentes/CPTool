using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate
{
    public class EngineeringCostItemCommandResponse : BaseResponse
    {
        public EngineeringCostItemCommandResponse() : base()
        {

        }

        public CommandEngineeringCostItem? EngineeringCostItemObject { get; set; }
    }
}