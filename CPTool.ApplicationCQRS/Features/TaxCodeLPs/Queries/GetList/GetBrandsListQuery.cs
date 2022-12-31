using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxCodeLPs.Queries.GetList
{
    public class GetTaxCodeLPsListQuery : IRequest<List<CommandTaxCodeLP>>
    {

    }
}
