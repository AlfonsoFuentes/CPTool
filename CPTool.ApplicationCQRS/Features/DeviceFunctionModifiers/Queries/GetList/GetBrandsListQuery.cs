using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.DeviceFunctionModifiers.Queries.GetList
{
    public class GetDeviceFunctionModifiersListQuery : IRequest<List<CommandDeviceFunctionModifier>>
    {

    }
}
