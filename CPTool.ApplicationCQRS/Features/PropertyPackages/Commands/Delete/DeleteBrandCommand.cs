using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertyPackages.Commands.Delete
{
    public class DeletePropertyPackageCommand : IRequest<DeletePropertyPackageCommandResponse>
    {
        public int Id { get; set; }
    }
}
