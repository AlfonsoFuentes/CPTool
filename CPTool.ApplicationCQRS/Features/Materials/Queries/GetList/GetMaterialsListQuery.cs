using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Materials.Queries.GetList
{
    public class GetMaterialsListQuery : IRequest<List<CommandMaterial>>
    {

    }
}
