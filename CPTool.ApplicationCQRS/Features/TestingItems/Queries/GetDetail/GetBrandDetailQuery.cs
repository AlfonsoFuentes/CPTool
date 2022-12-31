using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TestingItems.Queries.GetDetail
{
    public class GetTestingItemDetailQuery : IRequest<CommandTestingItem>
    {
        public int Id { get; set; }
    }
}
