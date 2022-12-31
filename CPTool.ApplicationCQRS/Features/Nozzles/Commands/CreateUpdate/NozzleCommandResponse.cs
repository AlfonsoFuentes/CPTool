using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate
{
    public class NozzleCommandResponse : BaseResponse
    {
        public NozzleCommandResponse() : base()
        {

        }

        public CommandNozzle? NozzleObject { get; set; }
    }
}