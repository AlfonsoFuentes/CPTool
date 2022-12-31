using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate
{
    public class ConnectionTypeCommandResponse : BaseResponse
    {
        public ConnectionTypeCommandResponse() : base()
        {

        }

        public CommandConnectionType? ConnectionTypeObject { get; set; }
    }
}