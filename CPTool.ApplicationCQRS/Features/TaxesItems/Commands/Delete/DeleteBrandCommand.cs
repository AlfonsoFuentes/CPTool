using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxesItems.Commands.Delete
{
    public class DeleteTaxesItemCommand : IRequest<DeleteTaxesItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
