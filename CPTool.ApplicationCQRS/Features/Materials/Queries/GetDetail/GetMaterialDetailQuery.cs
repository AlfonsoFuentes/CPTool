using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Materials.Queries.GetDetail
{
    public class GetMaterialDetailQuery : IRequest<CommandMaterial>
    {
        public int Id { get; set; }
    }
}
