using AutoMapper;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Suppliers.Queries.GetDetail
{
    public class GetSupplierDetailQueryHandler : IRequestHandler<GetSupplierDetailQuery, CommandSupplier>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetSupplierDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandSupplier> Handle(GetSupplierDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositorySupplier.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandSupplier>(table);
            return dto;
        }
    }
}
