using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ElectricalItems.Commands.Delete
{
    public class DeleteElectricalItemCommand : IRequest<DeleteElectricalItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
