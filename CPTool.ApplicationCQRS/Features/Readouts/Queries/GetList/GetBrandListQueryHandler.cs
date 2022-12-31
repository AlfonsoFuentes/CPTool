using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Readouts.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Readouts.Queries.GetList
{
    public class GetReadoutListQueryHandler : IRequestHandler<GetReadoutsListQuery, List<CommandReadout>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetReadoutListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandReadout>> Handle(GetReadoutsListQuery request, CancellationToken cancellationToken)
        {
            var allReadout = (await _UnitOfWork.RepositoryReadout.GetAllAsync());
            return _mapper.Map<List<CommandReadout>>(allReadout);
        }
    }
}
