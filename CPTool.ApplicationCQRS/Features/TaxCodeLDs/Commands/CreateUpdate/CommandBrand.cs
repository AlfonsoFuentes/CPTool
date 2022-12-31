using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate
{
    public class CommandTaxCodeLD : CommandBase, IRequest<TaxCodeLDCommandResponse>
    {


        public List<CommandSupplier> Suppliers { get; set; } = new();

    }

}
