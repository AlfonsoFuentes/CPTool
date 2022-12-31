using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetDetail
{
    public class GetTaxCodeLDDetailQuery : IRequest<CommandTaxCodeLD>
    {
        public int Id { get; set; }
    }
}
