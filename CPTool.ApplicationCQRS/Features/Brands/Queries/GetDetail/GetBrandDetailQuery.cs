using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Brands.Queries.GetDetail
{
    public class GetBrandDetailQuery : IRequest<CommandBrand>
    {
        public int Id { get; set; }
    }
}
