using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctions.Commands.Delete
{
    public class DeleteDeviceFunctionCommand : IRequest<DeleteDeviceFunctionCommandResponse>
    {
        public int Id { get; set; }
    }
}
