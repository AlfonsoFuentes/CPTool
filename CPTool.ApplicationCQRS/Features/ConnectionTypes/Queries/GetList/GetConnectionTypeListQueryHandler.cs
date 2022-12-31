using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetList;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetList
{
    public class GetConnectionTypeListQueryHandler : IRequestHandler<GetConnectionTypesListQuery, List<CommandConnectionType>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetConnectionTypeListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandConnectionType>> Handle(GetConnectionTypesListQuery request, CancellationToken cancellationToken)
        {
            var allConnectionType = (await _UnitOfWork.RepositoryConnectionType.GetAllAsync());
            return _mapper.Map<List<CommandConnectionType>>(allConnectionType);
        }
    }
}
