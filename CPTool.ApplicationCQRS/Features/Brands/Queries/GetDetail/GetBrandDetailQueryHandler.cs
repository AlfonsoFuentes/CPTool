using AutoMapper;
using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Brands.Queries.GetDetail
{
    public class GetBrandDetailQueryHandler : IRequestHandler<GetBrandDetailQuery, CommandBrand>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetBrandDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandBrand> Handle(GetBrandDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryBrand.FindAsync(request.Id);
            var dto = _mapper.Map<CommandBrand>(table);
            return dto;
        }
    }
}
