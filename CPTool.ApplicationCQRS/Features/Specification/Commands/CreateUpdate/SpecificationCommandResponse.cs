using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate
{
    public class SpecificationCommandResponse : BaseResponse
    {
        public SpecificationCommandResponse() : base()
        {

        }

        public CommandSpecification? SpecificationObject { get; set; }
    }
}