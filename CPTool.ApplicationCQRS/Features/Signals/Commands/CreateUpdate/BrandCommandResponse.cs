using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate
{
    public class SignalCommandResponse : BaseResponse
    {
        public SignalCommandResponse() : base()
        {

        }

        public CommandSignal? SignalObject { get; set; }
    }
}