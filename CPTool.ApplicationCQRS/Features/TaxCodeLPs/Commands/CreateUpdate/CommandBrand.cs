using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate
{
    public class CommandTaxCodeLP : CommandBase, IRequest<TaxCodeLPCommandResponse>
    {



        public List<CommandSupplier> Suppliers { get; set; } = new();
    }

}
