using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetList
{
    public class GetSupplierListQueryHandler : IRequestHandler<GetSuppliersListQuery, List<CommandSupplier>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSupplierListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandSupplier>> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Supplier> allSupplier = null!;
            if (request.BrandId == 0)
            {
                allSupplier = (await _UnitOfWork.RepositorySupplier.GetAllAsync());
            }
            else
            {
                allSupplier = (await _UnitOfWork.RepositoryBrandSupplier.GetAllAsync(x => x.BrandId == request.BrandId)).Select(y => y.Supplier).ToList();
            }

            return _mapper.Map<List<CommandSupplier>>(allSupplier);
        }
    }
}
