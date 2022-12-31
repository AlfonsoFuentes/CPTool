using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate
{
    public class ContingencyItemCommandResponse : BaseResponse
    {
        public ContingencyItemCommandResponse() : base()
        {

        }

        public CommandContingencyItem? ContingencyItemObject { get; set; }
    }
}