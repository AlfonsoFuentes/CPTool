using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate
{
    public class CommandTaxCodeLD : CommandBase, IRequest<TaxCodeLDCommandResponse>
    {

        public bool IsTwoWayMatch { get; set; }
        public List<CommandSupplier> Suppliers { get; set; } = new();

    }

}
