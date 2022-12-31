using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TaxesItems.Queries.GetDetail
{
    public class GetTaxesItemDetailQuery : IRequest<CommandTaxesItem>
    {
        public int Id { get; set; }
    }
}
