using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctions.Queries.GetDetail
{
    public class GetDeviceFunctionDetailQuery : IRequest<CommandDeviceFunction>
    {
        public int Id { get; set; }
    }
}
