using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate
{
    public class PipeClassCommandResponse : BaseResponse
    {
        public PipeClassCommandResponse() : base()
        {

        }

        public CommandPipeClass? PipeClassObject { get; set; }
    }
}