using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipingItems.Queries.GetDetail
{
    public class GetPipingItemDetailQueryHandler : IRequestHandler<GetPipingItemDetailQuery, CommandPipingItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipingItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPipingItem> Handle(GetPipingItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPipingItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPipingItem>(table);
            return dto;
        }
    }
}
