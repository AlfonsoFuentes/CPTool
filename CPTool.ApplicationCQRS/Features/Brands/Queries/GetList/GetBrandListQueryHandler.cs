using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Brands.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Brands.Queries.GetList
{
    public class GetBrandListQueryHandler : IRequestHandler<GetBrandsListQuery, List<CommandBrand>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetBrandListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandBrand>> Handle(GetBrandsListQuery request, CancellationToken cancellationToken)
        {
            var allBrand = (await _UnitOfWork.RepositoryBrand.GetAllAsync());
            return _mapper.Map<List<CommandBrand>>(allBrand);
        }
    }
}
