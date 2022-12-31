using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetList;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.ProcessFluids.Queries.GetList
{
    public class GetProcessFluidListQueryHandler : IRequestHandler<GetProcessFluidsListQuery, List<CommandProcessFluid>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetProcessFluidListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandProcessFluid>> Handle(GetProcessFluidsListQuery request, CancellationToken cancellationToken)
        {
            var allProcessFluid = await _UnitOfWork.RepositoryProcessFluid.GetAllAsync();
            
            return _mapper.Map<List<CommandProcessFluid>>(allProcessFluid);
        }
    }
}
