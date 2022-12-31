using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Commands.Delete
{
    public class DeleteDeviceFunctionModifierCommand : IRequest<DeleteDeviceFunctionModifierCommandResponse>
    {
        public int Id { get; set; }
    }
}
