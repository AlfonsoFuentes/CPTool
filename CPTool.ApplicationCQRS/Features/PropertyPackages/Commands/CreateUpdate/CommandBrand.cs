using CPTool.ApplicationCQRS.Responses;
using EquipmentCalculation;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate
{
    public class CommandPropertyPackage : CommandBase, IRequest<PropertyPackageCommandResponse>
    {


        public string TagLetter { get; set; } = "";
        public PropertyPackageCalculator? PropertyPackageCalculator { get; set; }

    }

}
