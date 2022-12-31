using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate
{
    public class PipeAccesoryCommandResponse : BaseResponse
    {
        public PipeAccesoryCommandResponse() : base()
        {

        }

        public CommandPipeAccesory? PipeAccesoryObject { get; set; }
    }
}