using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate
{
    public class PropertySpecificationCommandResponse : BaseResponse
    {
        public PropertySpecificationCommandResponse() : base()
        {

        }

        public CommandPropertySpecification? PropertySpecificationObject { get; set; }
    }
}