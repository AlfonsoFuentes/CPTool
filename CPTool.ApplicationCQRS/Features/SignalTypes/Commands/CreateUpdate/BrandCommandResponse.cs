using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate
{
    public class SignalTypeCommandResponse : BaseResponse<CommandSignalType>
    {
        public SignalTypeCommandResponse() : base()
        {

        }
    }
}