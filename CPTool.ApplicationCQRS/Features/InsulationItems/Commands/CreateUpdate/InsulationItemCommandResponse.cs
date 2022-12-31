using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate
{
    public class InsulationItemCommandResponse : BaseResponse
    {
        public InsulationItemCommandResponse() : base()
        {

        }

        public CommandInsulationItem? InsulationItemObject { get; set; }
    }
}