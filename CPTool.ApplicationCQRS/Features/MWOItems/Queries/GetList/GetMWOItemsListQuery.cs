using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.MWOItems.Queries.GetList
{
    public class GetMWOItemsListQuery : IRequest<List<CommandMWOItem>>
    {
        public int MWOId { get; set; }
        public bool Budget { get; set; } = false;
       
    }
}
