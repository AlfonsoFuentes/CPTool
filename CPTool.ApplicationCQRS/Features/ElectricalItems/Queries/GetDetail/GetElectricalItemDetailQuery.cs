using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalItems.Queries.GetDetail
{
    public class GetElectricalItemDetailQuery : IRequest<CommandElectricalItem>
    {
        public int Id { get; set; }
    }
}
