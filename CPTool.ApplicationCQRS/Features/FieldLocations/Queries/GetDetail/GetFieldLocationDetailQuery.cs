using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetDetail
{
    public class GetFieldLocationDetailQuery : IRequest<CommandFieldLocation>
    {
        public int Id { get; set; }
    }
}
