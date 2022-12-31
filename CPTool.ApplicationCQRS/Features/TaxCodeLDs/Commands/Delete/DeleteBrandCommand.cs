using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Commands.Delete
{
    public class DeleteTaxCodeLDCommand : IRequest<DeleteTaxCodeLDCommandResponse>
    {
        public int Id { get; set; }
    }
}
