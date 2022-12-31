using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Queries.GetList
{
    public class GetElectricalBoxsListQuery : IRequest<List<CommandElectricalBox>>
    {

    }
}
