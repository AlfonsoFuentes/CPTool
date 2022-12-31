using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.BrandSuppliers.Queries.GetList;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.BrandSuppliers.Queries.GetList
{
    public class GetBrandSupplierListQueryHandler : IRequestHandler<GetBrandSuppliersListQuery, List<CommandBrandSupplier>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetBrandSupplierListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandBrandSupplier>> Handle(GetBrandSuppliersListQuery request, CancellationToken cancellationToken)
        {
            var allBrandSupplier = (await _UnitOfWork.RepositoryBrandSupplier.GetAllAsync());
            return _mapper.Map<List<CommandBrandSupplier>>(allBrandSupplier);
        }
    }
}
