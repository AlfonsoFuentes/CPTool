using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.PipeDiameters.Queries.GetList
{
    public class GetPipeDiameterListQueryHandler : IRequestHandler<GetPipeDiametersListQuery, List<CommandPipeDiameter>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipeDiameterListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPipeDiameter>> Handle(GetPipeDiametersListQuery request, CancellationToken cancellationToken)
        {
            var allPipeDiameter = await _UnitOfWork.RepositoryPipeDiameter.GetAllAsync(x=>x.dPipeClassId==request.PipeClassId);
            return _mapper.Map<List<CommandPipeDiameter>>(allPipeDiameter);
        }
    }
}
