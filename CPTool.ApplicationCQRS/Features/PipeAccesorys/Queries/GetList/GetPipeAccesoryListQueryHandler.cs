using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PipeAccesorys.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.PipeAccesorys.Queries.GetList
{
    public class GetPipeAccesoryListQueryHandler : IRequestHandler<GetPipeAccesorysListQuery, List<CommandPipeAccesory>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipeAccesoryListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPipeAccesory>> Handle(GetPipeAccesorysListQuery request, CancellationToken cancellationToken)
        {
            var allPipeAccesory = (await _UnitOfWork.RepositoryPipeAccesory.GetAllAsync());
            return _mapper.Map<List<CommandPipeAccesory>>(allPipeAccesory);
        }
    }
}
