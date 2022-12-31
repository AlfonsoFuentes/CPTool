using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate
{
    public class MWOCommandResponse : BaseResponse
    {
        public MWOCommandResponse() : base()
        {

        }

        public CommandMWO? MWOObject { get; set; }
    }
}