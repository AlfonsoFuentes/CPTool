using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Commands.Delete
{
    public class DeleteTaxCodeLPCommand : IRequest<DeleteTaxCodeLPCommandResponse>
    {
        public int Id { get; set; }
    }
}
