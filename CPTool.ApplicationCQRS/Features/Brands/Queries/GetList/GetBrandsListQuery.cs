using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Brands.Queries.GetList
{
    public class GetBrandsListQuery : IRequest<List<CommandBrand>>
    {

    }
}
