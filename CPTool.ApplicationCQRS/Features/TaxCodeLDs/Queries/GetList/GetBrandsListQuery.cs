using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLDs.Queries.GetList
{
    public class GetTaxCodeLDsListQuery : IRequest<List<CommandTaxCodeLD>>
    {

    }
}
