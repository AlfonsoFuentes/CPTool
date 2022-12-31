using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate
{
    public class EHSItemCommandResponse : BaseResponse
    {
        public EHSItemCommandResponse() : base()
        {

        }

        public CommandEHSItem? EHSItemObject { get; set; }
    }
}