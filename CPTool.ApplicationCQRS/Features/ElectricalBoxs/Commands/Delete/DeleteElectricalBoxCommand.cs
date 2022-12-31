using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalBoxs.Commands.Delete
{
    public class DeleteElectricalBoxCommand : IRequest<DeleteElectricalBoxCommandResponse>
    {
        public int Id { get; set; }
    }
}
