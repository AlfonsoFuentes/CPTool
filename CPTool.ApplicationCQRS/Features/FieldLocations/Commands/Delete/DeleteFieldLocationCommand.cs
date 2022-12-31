using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FieldLocations.Commands.Delete
{
    public class DeleteFieldLocationCommand : IRequest<DeleteFieldLocationCommandResponse>
    {
        public int Id { get; set; }
    }
}
