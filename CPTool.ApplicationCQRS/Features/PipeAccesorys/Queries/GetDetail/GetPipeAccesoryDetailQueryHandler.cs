using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeAccesorys.Queries.GetDetail
{
    public class GetPipeAccesoryDetailQueryHandler : IRequestHandler<GetPipeAccesoryDetailQuery, CommandPipeAccesory>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipeAccesoryDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPipeAccesory> Handle(GetPipeAccesoryDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPipeAccesory.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPipeAccesory>(table);
            return dto;
        }
    }
}
