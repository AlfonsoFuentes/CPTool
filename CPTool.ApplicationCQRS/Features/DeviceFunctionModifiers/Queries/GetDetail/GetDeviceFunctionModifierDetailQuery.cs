using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Queries.GetDetail
{
    public class GetDeviceFunctionModifierDetailQuery : IRequest<CommandDeviceFunctionModifier>
    {
        public int Id { get; set; }
    }
}
