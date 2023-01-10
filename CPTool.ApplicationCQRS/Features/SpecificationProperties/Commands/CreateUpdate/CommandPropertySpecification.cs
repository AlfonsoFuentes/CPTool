using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate
{
    public class CommandPropertySpecification : CommandBase, IRequest<PropertySpecificationCommandResponse>
    {

        public int? SpecificationId => Specification==null ? null : Specification!.Id;
        public CommandSpecification? Specification { get; set; }
        public string Value { get; set; } = string.Empty;

        public int? MWOItemId => MWOItem == null ? null : MWOItem!.Id;
        public CommandMWOItem? MWOItem { get; set; }

    }

}
