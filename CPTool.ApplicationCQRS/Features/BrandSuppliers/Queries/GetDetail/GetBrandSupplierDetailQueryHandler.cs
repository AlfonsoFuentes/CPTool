using AutoMapper;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.BrandSuppliers.Queries.GetDetail
{
    public class GetBrandSupplierDetailQueryHandler : IRequestHandler<GetBrandSupplierDetailQuery, CommandBrandSupplier>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetBrandSupplierDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandBrandSupplier> Handle(GetBrandSupplierDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryBrandSupplier.FindAsync(request.Id);
            var dto = _mapper.Map<CommandBrandSupplier>(table);
            return dto;
        }
    }
}
