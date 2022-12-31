using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Materials.Commands.Delete
{
    public class DeleteMaterialCommand : IRequest<DeleteMaterialCommandResponse>
    {
        public int Id { get; set; }
    }
}
