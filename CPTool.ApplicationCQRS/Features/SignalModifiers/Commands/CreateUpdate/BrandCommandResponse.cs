using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate
{
    public class SignalModifierCommandResponse : BaseResponse
    {
        public SignalModifierCommandResponse() : base()
        {

        }

        public CommandSignalModifier? SignalModifierObject { get; set; }
    }
}