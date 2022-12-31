using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate
{
    public class AlterationItemCommandResponse : BaseResponse
    {
        public AlterationItemCommandResponse() : base()
        {

        }

        public CommandAlterationItem? AlterationItemObject { get; set; }
    }
}