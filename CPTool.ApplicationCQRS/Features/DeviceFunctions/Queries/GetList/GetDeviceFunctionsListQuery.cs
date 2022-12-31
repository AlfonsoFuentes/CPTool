using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctions.Queries.GetList
{
    public class GetDeviceFunctionsListQuery : IRequest<List<CommandDeviceFunction>>
    {

    }
}
