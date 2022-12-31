using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetList;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetList
{
    public class GetFieldLocationListQueryHandler : IRequestHandler<GetFieldLocationsListQuery, List<CommandFieldLocation>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetFieldLocationListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandFieldLocation>> Handle(GetFieldLocationsListQuery request, CancellationToken cancellationToken)
        {
            var allFieldLocation = (await _UnitOfWork.RepositoryFieldLocation.GetAllAsync());
            return _mapper.Map<List<CommandFieldLocation>>(allFieldLocation);
        }
    }
}
