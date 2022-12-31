using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate
{
    public class SignalTypeCommandResponse : BaseResponse
    {
        public SignalTypeCommandResponse() : base()
        {

        }

        public CommandSignalType? SignalTypeObject { get; set; }
    }
}