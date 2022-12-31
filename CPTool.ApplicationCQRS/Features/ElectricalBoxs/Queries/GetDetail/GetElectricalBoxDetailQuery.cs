using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetDetail
{
    public class GetElectricalBoxDetailQuery : IRequest<CommandElectricalBox>
    {
        public int Id { get; set; }
    }
}
