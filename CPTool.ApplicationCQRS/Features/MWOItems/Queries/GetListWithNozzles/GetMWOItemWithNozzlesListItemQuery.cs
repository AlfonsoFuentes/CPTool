using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Queries.GetListWithNozzles
{
    public class GetMWOItemWithNozzlesListItemQuery : IRequest<List<CommandMWOItem>>
    {
        public StreamType type { get; set; }
        public int ModelId { get; set; }

        public int SearchModelId { get; set; }
        public int MWOId { get; set; }

    }
}
