using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetDetail
{
    public class GetTaxCodeLPDetailQuery : IRequest<CommandTaxCodeLP>
    {
        public int Id { get; set; }
    }
}
