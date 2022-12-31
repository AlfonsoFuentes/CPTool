using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeDiameters.Commands.Delete
{
    public class DeletePipeDiameterCommand : IRequest<DeletePipeDiameterCommandResponse>
    {
        public int Id { get; set; }
    }
}
