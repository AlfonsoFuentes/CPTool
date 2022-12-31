using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InstrumentItems.Queries.GetList
{
    public class GetInstrumentItemsListQuery : IRequest<List<CommandInstrumentItem>>
    {

    }
}
