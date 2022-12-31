using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate
{
    public class FieldLocationCommandResponse : BaseResponse
    {
        public FieldLocationCommandResponse() : base()
        {

        }

        public CommandFieldLocation? FieldLocationObject { get; set; }
    }
}