using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate
{
    public class PropertyPackageCommandResponse : BaseResponse
    {
        public PropertyPackageCommandResponse() : base()
        {

        }

        public CommandPropertyPackage? PropertyPackageObject { get; set; }
    }
}